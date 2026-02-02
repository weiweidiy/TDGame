using Adic;
using JFramework.Game.View;
using System;
using Tiktok;
using UnityEngine;

namespace JFramework
{
    public class TiktokGameDataManager
    {

        long timeOffset { get; set; }
        long serverLoginTime;

        [Inject]
        TiktokConfigManager configManager;
        [Inject]
        BuildingModel buildingModel;
        [Inject]
        LevelsModel levelsModel;
        [Inject]
        protected ILanguageManager languageManager;
        [Inject]
        protected SamuraisModel samuraisModel;

        /// <summary>
        /// 进入游戏需要调用此方法，进行时间校准
        /// </summary>
        /// <param name="serverTime"></param>
        public void Login(long serverTime)
        {
            timeOffset = (long)Time.realtimeSinceStartup;
            //timeOffset = serverTime - timeOffset;

            serverLoginTime = serverTime;
            Debug.Log("login " + serverLoginTime);
        }

        /// <summary>
        /// 获取服务器时间戳，单位毫秒
        /// </summary>
        /// <returns></returns>
        public long GetServerTime()
        {
            var serverTime = serverLoginTime + (long)Time.realtimeSinceStartup - timeOffset;
            return serverTime;
        }

        #region samurai
        public SamuraiDetailInfo GetSamuraiDetailInfo(int samuraiId)
        {
            var dto = samuraisModel.Get(samuraiId.ToString());
            if (dto == null)
                return null;
            var info = new SamuraiDetailInfo();
            info.name = languageManager.GetText(configManager.GetSamuraiNameLid(dto.BusinessId));
            info.level = dto.Level;
            info.hp = dto.CurHp;
            info.maxHp = configManager.GetFormulaMaxHpByLevel(info.level);
            info.exp = dto.Experience;
            info.maxExp = configManager.GetFormulaLevelUpExperience(info.level + 1);
            info.power = configManager.GetSamuraiPower(dto.BusinessId);
            info.def = configManager.GetSamuraiDef(dto.BusinessId);
            info.intel = configManager.GetSamuraiIntel(dto.BusinessId);
            info.soldierName = languageManager.GetText(configManager.GetSoldierNameLid(dto.BusinessId));
            var soliderBusinessId = dto.SoldierBusinessId;
            info.attack = configManager.GetSoldierAttack(soliderBusinessId);
            info.defence = configManager.GetSoldierDefence(soliderBusinessId);
            info.speed = configManager.GetSoldierSpeed(soliderBusinessId);


            return info;
        }
        #endregion

        #region building
        public int GetBuildingLevel(string businessId)
        {
            var building = buildingModel.Get(businessId);
            if (building != null)
            {
                return building.Level;
            }
            return 0;
        }

        /// <summary>
        /// 是否在升级中
        /// </summary>
        /// <param name="businessId"></param>
        /// <returns></returns>
        public bool IsBuildingUpgrading(string businessId)
        {
            var building = buildingModel.Get(businessId);
            if (building != null && building.UpgradeEndTime != null)
            {
                var serverTime = GetServerTime();
                // 将 serverTime（毫秒）转换为 DateTime（UTC 时间）
                DateTime serverDateTime = DateTimeOffset.FromUnixTimeMilliseconds(serverTime).UtcDateTime;
                return building.UpgradeEndTime > serverDateTime;
            }
            return false;
        }

        /// <summary>
        /// 是否可以建造该建筑
        /// </summary>
        /// <param name="businessId"></param>
        /// <returns></returns>
        public bool CanBuildingBuild(string businessId)
        {
            var building = buildingModel.Get(businessId);
            if (building != null)
                return false;

            var unlockLevel = configManager.GetBuildingUnlockLevel(businessId);
            if (building == null && levelsModel.IsLevelUnlocked(unlockLevel.ToString()))
                return true;

            return false;
        }

        #endregion

        #region levels
        public int GetLevelTotalStars(string levelUid)
        {
            int result = 0;
            var  nodesDto = levelsModel.GetAll();
            foreach(var dto in nodesDto)
            {
                var uid = configManager.GetLevelUid(dto.BusinessId);
                if(levelUid != uid)
                    continue;

                result += dto.Process;
            }
            return result;
        }
        #endregion
    }

}

