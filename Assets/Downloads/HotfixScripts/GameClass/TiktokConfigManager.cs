using JFramework.Game;
using Adic;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Tiktok;
using System.Linq;
using UnityEngine;
using Game.Common;

namespace JFramework
{
    public class TiktokConfigManager : IJConfigManager
    {
        [Inject]
        IJConfigManager jConfigManager;

        #region 基础接口
        public Task PreloadAllAsync(string path, string extend, IProgress<LoadProgress> progress = null)
        {
            return jConfigManager.PreloadAllAsync(path, extend, progress);
        }

        public void RegisterTable<TTable, TItem>(string path, IDeserializer deserializer)
            where TTable : IConfigTable<TItem>, new()
            where TItem : IUnique
        {
            jConfigManager.RegisterTable<TTable, TItem>(path, deserializer);
        }

        public List<TItem> Get<TItem>(Func<TItem, bool> predicate) where TItem : class, IUnique
        {
            return jConfigManager.Get<TItem>(predicate);
        }

        public TItem Get<TItem>(string uid) where TItem : class, IUnique
        {
            return jConfigManager.Get<TItem>(uid);
        }

        public List<TItem> GetAll<TItem>() where TItem : class, IUnique
        {
            return jConfigManager.GetAll<TItem>();
        }
        #endregion

        #region 默认属性
        public string GetDefaultFirstNode()
        {
            return "1";
        }



        #endregion

        #region BGM
        public string GetLoginMusic()
        {
            return jConfigManager.Get<AudiosCfgData>("1").Path;
        }

        public string GetLevelMusic(string levelBusinessId)
        {
            var levelCfg = jConfigManager.Get<LevelsCfgData>(levelBusinessId);
            if (levelCfg == null)
                return null;
            var audioCfg = jConfigManager.Get<AudiosCfgData>(levelCfg.AudioUid);
            if (audioCfg == null)
                return null;
            return audioCfg.Path;

        }

        public string GetCombatMusic(string levelNodeBusinessId)
        {
            var levelNodeCfg = jConfigManager.Get<LevelsNodesCfgData>(levelNodeBusinessId);
            if (levelNodeCfg == null)
                return null;
            var audioCfg = jConfigManager.Get<AudiosCfgData>(levelNodeCfg.AudioUid);
            if (audioCfg == null)
                return null;
            return audioCfg.Path;
        }

        public string GetCastleMusic()
        {
            return jConfigManager.Get<AudiosCfgData>("4").Path;
        }
        #endregion

        #region 关卡相关
        public bool IsNewLevelFirstNode(string levelNodeBusinessId)
        {
            var nodeCfgData = jConfigManager.Get<LevelsNodesCfgData>(levelNodeBusinessId);
            var preUid = nodeCfgData.PreUid;
            if (preUid == "0")
                return true;
            var preNode = jConfigManager.Get<LevelsNodesCfgData>(preUid);
            return preNode.LevelUid != nodeCfgData.LevelUid;

        }
        public List<string> GetNextLevelNode(string curLevelNodeBusinessId)
        {
            var nodeCfg = jConfigManager.Get<LevelsNodesCfgData>(curLevelNodeBusinessId);
            return nodeCfg.NextUid;
        }

        public string GetNextLevel(string curLevelBusinessId)
        {
            var levelCfg = jConfigManager.Get<LevelsCfgData>(curLevelBusinessId);
            return levelCfg.Next;
        }

        public string GetPreLevel(string curLevelBusinessId)
        {
            var levelCfg = jConfigManager.Get<LevelsCfgData>(curLevelBusinessId);
            return levelCfg.Pre;
        }

        public string GetLevelUid(string levelNodeBusinessId)
        {
            var nodeCfg = jConfigManager.Get<LevelsNodesCfgData>(levelNodeBusinessId);
            if (nodeCfg == null)
                return null;
            return nodeCfg.LevelUid;
        }

        public string GetLevelNameLid(string levelUid)
        {
            var levelCfg = jConfigManager.Get<LevelsCfgData>(levelUid);
            if (levelCfg == null)
                return null;
            return levelCfg.Name;

        }

        public int GetLevelMaxStars(string levelBusinessId)
        {
           var levelNodes = jConfigManager.Get<LevelsNodesCfgData>((i) => i.LevelUid == levelBusinessId);
            int maxStars = 0;
            foreach(var node in levelNodes)
            {
                maxStars += node.AchievementUid.Count;
            }
            return maxStars;
        }
        #endregion

        #region 关卡节点相关
        public bool IsBelongToLevel(string levelNodeBusinessId, string levelBusinessId)
        {
            var nodeCfg = jConfigManager.Get<LevelsNodesCfgData>(levelNodeBusinessId);
            if (nodeCfg == null)
                return false;
            return nodeCfg.LevelUid == levelBusinessId;
        }
        #endregion

        #region 战斗相关
        public string GetCombatDamageTextPrefab()
        {
            return jConfigManager.Get<PrefabsCfgData>("1003").PrefabName;
        }

        public string GetCombatActionNameTextPrefab()
        {
            return jConfigManager.Get<PrefabsCfgData>("1004").PrefabName;
        }

        public string GetLanguageBusinessIdByActionBusiness(string actionBusinessId)
        {
            var actionCfg = jConfigManager.Get<ActionsCfgData>(actionBusinessId);
            if (actionCfg == null)
                return null;
            return actionCfg.Name;
        }

        public ActionTiming GetActionTiming(string actionBusinessId)
        {
            var actionCfg = jConfigManager.Get<ActionsCfgData>(actionBusinessId);
            return (ActionTiming)actionCfg.ActionTiming;
        }

        public bool GetActionNeedShowName(string actionBusinessId)
        {
            var actionCfg = jConfigManager.Get<ActionsCfgData>(actionBusinessId);
            if (actionCfg == null)
                return false;
            if (actionCfg.ShowName == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取技能动作动画名字
        /// </summary>
        /// <param name="actionBusinessId"></param>
        /// <returns></returns>
        public string GetActionUnitAnimationName(string actionBusinessId)
        {
            var actionCfg = jConfigManager.Get<ActionsCfgData>(actionBusinessId);
            if (actionCfg == null)
                return null;
            return actionCfg.AnimationName;
        }

        /// <summary>
        /// 获取技能命中时候特效名字
        /// </summary>
        /// <param name="actionBusinessId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string GetActionHitAnimationName(string actionBusinessId)
        {
            return "Hit"; //to do: 使用配置
        }

        //public string GetLanguage(string languageBusinessId)
        //{
        //    return tiktokConfigManager.Get<LanguagesCfgData>(languageBusinessId).Key;
        //}
        #endregion

        #region 武将相关
        public string GetSamuraiHeadIconBusinessId(string samuraiBusinessId)
        {
            var samuraiCfg = jConfigManager.Get<SamuraiCfgData>(samuraiBusinessId);
            if (samuraiCfg == null)
                return null;

            var textureCfg = jConfigManager.Get<TexturesCfgData>(samuraiCfg.HeadIconUid);
            return textureCfg.Path;

        }

        public string GetSamuraiRareIconBusinessId(string businessId)
        {
            var samuraiCfg = jConfigManager.Get<SamuraiCfgData>(businessId);
            if (samuraiCfg == null)
                return null;
            var samuraiRareCfgData = jConfigManager.Get<SamuraiRareCfgData>(samuraiCfg.Rare.ToString());
            var textureCfg = jConfigManager.Get<TexturesCfgData>(samuraiRareCfgData.TextureUid);
            return textureCfg.Path;
        }

        public string GetSamuraiNameLid(string samuraiBusinessId)
        {
            var samuraiCfg = jConfigManager.Get<SamuraiCfgData>(samuraiBusinessId);
            if (samuraiCfg == null)
                return null;
            return samuraiCfg.Name;
        }

        /// <summary>
        /// 获取武士的战斗力
        /// </summary>
        /// <param name="samuraiBusinessId"></param>
        /// <returns></returns>
        public int GetSamuraiPower(string samuraiBusinessId)
        {
            return Get<SamuraiCfgData>(samuraiBusinessId)?.Power ?? 0;
        }

        /// <summary>
        /// 获取武士守备力
        /// </summary>
        /// <param name="samuraiBusinessId"></param>
        /// <returns></returns>
        public int GetSamuraiDef(string samuraiBusinessId)
        {
            return Get<SamuraiCfgData>(samuraiBusinessId)?.Def ?? 0;
        }

        /// <summary>
        /// 获取武士的智力
        /// </summary>
        /// <param name="samuraiBusinessId"></param>
        /// <returns></returns>
        public int GetSamuraiIntel(string samuraiBusinessId)
        {
            return Get<SamuraiCfgData>(samuraiBusinessId)?.Intel ?? 0;
        }

        /// <summary>
        /// 获取武士的速度
        /// </summary>
        /// <param name="samuraiBusinessId"></param>
        /// <returns></returns>
        public int GetSamuraiSpeed(string samuraiBusinessId)
        {
            return Get<SamuraiCfgData>(samuraiBusinessId)?.Speed ?? 0;
        }

        /// <summary>
        /// 获取武士的性别
        /// </summary>
        /// <param name="samuraiBusinessId"></param>
        /// <returns></returns>
        public int GetSamuraiSex(string samuraiBusinessId)
        {
            return 0; // to do: 读取配置
        }

        #endregion

        #region 兵种相关
        public string[] GetSoldierAnimation(string soldierBusinessId)
        {
            var soldierCfg = jConfigManager.Get<SoldiersCfgData>(soldierBusinessId);
            return soldierCfg.Textures.ToArray();
        }

        public string GetSoldierNameLid(string soldierBusinessId)
        {
            var soldierCfg = jConfigManager.Get<SoldiersCfgData>(soldierBusinessId);
            if (soldierCfg == null)
                return null;
            //Debug.Log("GetSoldierNameLid: " + soldierCfg.Key);
            return soldierCfg.Name;
        }

        public int GetSoldierAttack(string soldierBusinessId)
        {
            var soldierCfg = jConfigManager.Get<SoldiersCfgData>(soldierBusinessId);
            if (soldierCfg == null)
                return 0;
            return soldierCfg.Atk;
        }

        public int GetSoldierDefence(string soldierBusinessId)
        {
            var soldierCfg = jConfigManager.Get<SoldiersCfgData>(soldierBusinessId);
            if (soldierCfg == null)
                return 0;
            return soldierCfg.Def;
        }

        public int GetSoldierSpeed(string soldierBusinessId)
        {
            var soldierCfg = jConfigManager.Get<SoldiersCfgData>(soldierBusinessId);
            if (soldierCfg == null)
                return 0;
            return soldierCfg.Speed;
        }
        #endregion

        #region 阵型相关
        public bool GetFormationPointValidByIndex(string formationBusinessId, int index, int homeLevel)
        {
            var pointData = jConfigManager.Get<FormationPointsUnlockCfgData>((i) => i.FormationBusinessId == formationBusinessId && i.PointIndex == index).SingleOrDefault();
            if (pointData == null)
            {
                throw new Exception($"FormationPointsUnlockCfgData not found for formationBusinessId: {formationBusinessId}, index: {index}");
            }
            return pointData.UnlockLevel != -1 && pointData.UnlockLevel <= homeLevel;
        }

        /// <summary>
        /// 获取阵型点位解锁等级
        /// </summary>
        /// <param name="formationBusinessId"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int GetFormationPointUnlockLevelByIndex(string formationBusinessId, int index)
        {
            var pointData = jConfigManager.Get<FormationPointsUnlockCfgData>((i) => i.FormationBusinessId == formationBusinessId && i.PointIndex == index).SingleOrDefault();
            if (pointData == null)
            {
                throw new Exception($"FormationPointsUnlockCfgData not found for formationBusinessId: {formationBusinessId}, index: {index}");
            }
            return pointData.UnlockLevel;
        }
        /// <summary>
        /// 获取所有阵型的BusinessId
        /// </summary>
        /// <returns></returns>
        public string[] GetAllFormationBusinessIds()
        {
            var formations = jConfigManager.GetAll<FormationsCfgData>();
            return formations.Select(f => f.Uid).ToArray();
        }

        public string GetFormationLanguageBusinessId(string formationBusinessId)
        {
            var formationCfg = jConfigManager.Get<FormationsCfgData>(formationBusinessId);
            if (formationCfg == null)
                return null;
            return formationCfg.Name;
        }

        public string GetFormationTextureUid(string formationBusinessId)
        {
            var formationCfg = jConfigManager.Get<FormationsCfgData>(formationBusinessId);
            if (formationCfg == null)
                return null;
            var textureCfg = jConfigManager.Get<TexturesCfgData>(formationCfg.TextureUid);
            return textureCfg.Path;
        }

        #endregion

        #region 货币相关
        public string GetCurrencySmallIconPath(string currencyBusinessId)
        {
            var currencyCfg = jConfigManager.Get<CurrenciesCfgData>(currencyBusinessId);
            if (currencyCfg == null)
                return null;
            var textureCfg = jConfigManager.Get<TexturesCfgData>(currencyCfg.SmallTextureUid);
            return textureCfg.Path;
        }

        public string GetCurrencyBigIconPath(string currencyBusinessId)
        {
            var currencyCfg = jConfigManager.Get<CurrenciesCfgData>(currencyBusinessId);
            if (currencyCfg == null)
                return null;
            var textureCfg = jConfigManager.Get<TexturesCfgData>(currencyCfg.BigTextureUid);
            return textureCfg.Path;
        }
        #endregion

        #region 主城相关
        public string GetCastlePrefabName()
        {
            return "Castle";
        }

        /// <summary>
        /// 提示可以建造的预制体名字
        /// </summary>
        /// <returns></returns>
        public string GetCanBuildPrefabName()
        {
            return "FingerMoveDown";
        }

        /// <summary>
        /// 可建造底部提示预制体
        /// </summary>
        /// <returns></returns>
        public string GetCanBuildingBottomPrefabName(string buildingBusinessId)
        {
            return "Building_3_CanBuild";
        }

        /// <summary>
        /// 建筑预制体名字
        /// </summary>
        /// <param name="buildingBusinessId"></param>
        /// <returns></returns>
        public string GetBuildingPrefabName(string buildingBusinessId)
        {
            var buildingCfg = jConfigManager.Get<BuildingsCfgData>(buildingBusinessId);
            if (buildingCfg == null)
                return null;
            var prefabCfg = jConfigManager.Get<PrefabsCfgData>(buildingCfg.PrefabUid);
            return prefabCfg.PrefabName;
        }

        /// <summary>
        /// 建筑名字的语言ID
        /// </summary>
        /// <param name="buildingBusinessId"></param>
        /// <returns></returns>
        public string GetBuildingNameLid(string buildingBusinessId)
        {
            var buildingCfg = jConfigManager.Get<BuildingsCfgData>(buildingBusinessId);
            if (buildingCfg == null)
                return null;
            return buildingCfg.Name;
        }

        /// <summary>
        /// 获取建筑的菜单配置
        /// </summary>
        /// <param name="buildingBusinessId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int[] GetBuildingMenusByBusinessId(string buildingBusinessId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取建筑解锁等级
        /// </summary>
        /// <param name="businessId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int GetBuildingUnlockLevel(string buildingBusinessId)
        {
            var buildingCfg = jConfigManager.Get<BuildingsCfgData>(buildingBusinessId);
            if (buildingCfg == null)
                throw new Exception($"BuildingsCfgData not found for businessId: {buildingBusinessId}");

            return buildingCfg.UnlockLevel;

        }

        /// <summary>
        /// 获取建筑参数
        /// </summary>
        /// <param name="buildingBusinessId"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int GetBuildingArg(string buildingBusinessId, int level)
        {

            var lst = Get<BuildingsUpgradeCostCfgData>((i) => i.BuildingUid.Equals(buildingBusinessId) && i.BuildingLevel.Equals(level));
            if (lst == null || lst.Count == 0)
            {
                throw new Exception($"No upgrade cost found for building: {buildingBusinessId} at level: {level}");
            }
            if (lst.Count > 1)
            {
                throw new Exception($"Multiple upgrade costs found for building: {buildingBusinessId} at level: {level}");
            }
            return lst[0].Arg;
        }

        #endregion

        #region 关卡节点阵型相关
        public string[] GetLevelNodeFormation(string levelNodeBusinessId)
        {
            var nodeCfg = Get<LevelsNodesCfgData>(levelNodeBusinessId);
            if (nodeCfg == null)
            {
                throw new Exception($"LevelNodeCfgData not found for businessId: {levelNodeBusinessId}");
            }
            var formationUid = nodeCfg.FormationUid;
            var foramtionCfg = Get<LevelNodeDeployCfgData>(formationUid);
            return foramtionCfg.UnitsUid.ToArray();
        }

        public string GetLevelNodeUnitSamuraiHeadSpriteBusinessId(string levelNodeUnitBusinessId)
        {
            var unitCfg = Get<LevelNodeUnitsCfgData>(levelNodeUnitBusinessId);
            if (unitCfg == null)
            {
                throw new Exception($"LevelNodeUnitCfgData not found for businessId: {levelNodeUnitBusinessId}");
            }
            var samuraiUid = unitCfg.SamuraiUid;
            return GetSamuraiHeadIconBusinessId(samuraiUid);
        }

        public int GetLevelNodeUnitSamuraiPower(string levelNodeUnitBusinessId)
        {
            var unitCfg = Get<LevelNodeUnitsCfgData>(levelNodeUnitBusinessId);
            if (unitCfg == null)
            {
                throw new Exception($"LevelNodeUnitCfgData not found for businessId: {levelNodeUnitBusinessId}");
            }
            var samuraiUid = unitCfg.SamuraiUid;
            return GetSamuraiPower(samuraiUid);
        }

        public int GetLevelNodeUnitSamuraiDef(string levelNodeUnitBusinessId)
        {
            var unitCfg = Get<LevelNodeUnitsCfgData>(levelNodeUnitBusinessId);
            if (unitCfg == null)
            {
                throw new Exception($"LevelNodeUnitCfgData not found for businessId: {levelNodeUnitBusinessId}");
            }
            var samuraiUid = unitCfg.SamuraiUid;
            return GetSamuraiDef(samuraiUid);
        }

        public int GetLevelNodeUnitSamuraiIntel(string levelNodeUnitBusinessId)
        {
            var unitCfg = Get<LevelNodeUnitsCfgData>(levelNodeUnitBusinessId);
            if (unitCfg == null)
            {
                throw new Exception($"LevelNodeUnitCfgData not found for businessId: {levelNodeUnitBusinessId}");
            }
            var samuraiUid = unitCfg.SamuraiUid;
            return GetSamuraiIntel(samuraiUid);
        }

        public int GetLevelNodeUnitSamuraiSpeed(string levelNodeUnitBusinessId)
        {
            var unitCfg = Get<LevelNodeUnitsCfgData>(levelNodeUnitBusinessId);
            if (unitCfg == null)
            {
                throw new Exception($"LevelNodeUnitCfgData not found for businessId: {levelNodeUnitBusinessId}");
            }
            var samuraiUid = unitCfg.SamuraiUid;
            return GetSamuraiSpeed(samuraiUid);
        }

        public int GetLevelNodeUnitPower(string levelNodeUnitBusinessId)
        {
            return GetLevelNodeUnitSamuraiPower(levelNodeUnitBusinessId);
        }

        public int GetLevelNodeUnitDef(string levelNodeUnitBusinessId)
        {
            return GetLevelNodeUnitSamuraiDef(levelNodeUnitBusinessId);
        }

        public int GetLevelNodeUnitIntel(string levelNodeUnitBusinessId)
        {
            return GetLevelNodeUnitSamuraiIntel(levelNodeUnitBusinessId);
        }

        public int GetLevelNodeUnitLevel(string levelNodeUnitBusinessId)
        {
            var unitCfg = Get<LevelNodeUnitsCfgData>(levelNodeUnitBusinessId);
            if (unitCfg == null)
            {
                throw new Exception($"LevelNodeUnitCfgData not found for businessId: {levelNodeUnitBusinessId}");
            }
            return unitCfg.Level;
        }

        public int GetLevelNodeUnitHp(string levelNodeUnitBusinessId)
        {
            var unitCfg = Get<LevelNodeUnitsCfgData>(levelNodeUnitBusinessId);
            if (unitCfg == null)
            {
                throw new Exception($"LevelNodeUnitCfgData not found for businessId: {levelNodeUnitBusinessId}");
            }
            return unitCfg.Hp + GetFormulaMaxHpByLevel(GetLevelNodeUnitLevel(levelNodeUnitBusinessId));
        }

        public int GetLevelNodeUnitAttack(string levelNodeUnitBusinessId)
        {
            var unitCfg = Get<LevelNodeUnitsCfgData>(levelNodeUnitBusinessId);
            if (unitCfg == null)
            {
                throw new Exception($"LevelNodeUnitCfgData not found for businessId: {levelNodeUnitBusinessId}");
            }
            return unitCfg.Atk + GetLevelNodeUnitSoldierAttack(levelNodeUnitBusinessId);
        }

        public int GetLevelNodeUnitDefence(string levelNodeUnitBusinessId)
        {
            var unitCfg = Get<LevelNodeUnitsCfgData>(levelNodeUnitBusinessId);
            if (unitCfg == null)
            {
                throw new Exception($"LevelNodeUnitCfgData not found for businessId: {levelNodeUnitBusinessId}");
            }
            return unitCfg.Def + GetLevelNodeUnitSoldierDefence(levelNodeUnitBusinessId);
        }

        public int GetLevelNodeUnitSpeed(string levelNodeUnitBusinessId)
        {
            var unitCfg = Get<LevelNodeUnitsCfgData>(levelNodeUnitBusinessId);
            if (unitCfg == null)
            {
                throw new Exception($"LevelNodeUnitCfgData not found for businessId: {levelNodeUnitBusinessId}");
            }
            return unitCfg.Speed + GetLevelNodeUnitSoldierSpeed(levelNodeUnitBusinessId) + GetLevelNodeUnitSamuraiSpeed(levelNodeUnitBusinessId);
        }

        public int GetLevelNodeUnitSoldierAttack(string levelNodeUnitBusinessId)
        {
            var unitCfg = Get<LevelNodeUnitsCfgData>(levelNodeUnitBusinessId);
            if (unitCfg == null)
            {
                throw new Exception($"LevelNodeUnitCfgData not found for businessId: {levelNodeUnitBusinessId}");
            }
            var soldierUid = unitCfg.SoldierUid;
            var soldierCfg = Get<SoldiersCfgData>(soldierUid);
            if (soldierCfg == null)
            {
                throw new Exception($"SoldierCfgData not found for soldierUid: {soldierUid}");
            }
            return soldierCfg.Atk;
        }

        public int GetLevelNodeUnitSoldierDefence(string levelNodeUnitBusinessId)
        {
            var unitCfg = Get<LevelNodeUnitsCfgData>(levelNodeUnitBusinessId);
            if (unitCfg == null)
            {
                throw new Exception($"LevelNodeUnitCfgData not found for businessId: {levelNodeUnitBusinessId}");
            }
            var soldierUid = unitCfg.SoldierUid;
            var soldierCfg = Get<SoldiersCfgData>(soldierUid);
            if (soldierCfg == null)
            {
                throw new Exception($"SoldierCfgData not found for soldierUid: {soldierUid}");
            }
            return soldierCfg.Def;
        }

        public int GetLevelNodeUnitSoldierSpeed(string levelNodeUnitBusinessId)
        {
            var unitCfg = Get<LevelNodeUnitsCfgData>(levelNodeUnitBusinessId);
            if (unitCfg == null)
            {
                throw new Exception($"LevelNodeUnitCfgData not found for businessId: {levelNodeUnitBusinessId}");
            }
            var soldierUid = unitCfg.SoldierUid;
            var soldierCfg = Get<SoldiersCfgData>(soldierUid);
            if (soldierCfg == null)
            {
                throw new Exception($"SoldierCfgData not found for soldierUid: {soldierUid}");
            }
            return soldierCfg.Speed;
        }

        public string GetLevelNodeUnitSoldierNameLid(string levelNodeUnitBusinessId)
        {
            var unitCfg = Get<LevelNodeUnitsCfgData>(levelNodeUnitBusinessId);
            if (unitCfg == null)
            {
                throw new Exception($"LevelNodeUnitCfgData not found for businessId: {levelNodeUnitBusinessId}");
            }
            var soldierUid = unitCfg.SoldierUid;
            return GetSoldierNameLid(soldierUid);
        }

        public string GetLevelNodeUnitSamuraiNameLid(string levelNodeUnitBusinessId)
        {
            var unitCfg = Get<LevelNodeUnitsCfgData>(levelNodeUnitBusinessId);
            if (unitCfg == null)
            {
                throw new Exception($"LevelNodeUnitCfgData not found for businessId: {levelNodeUnitBusinessId}");
            }
            var samuraiUid = unitCfg.SamuraiUid;
            return GetSamuraiNameLid(samuraiUid);
        }
        #endregion

        #region 关卡节点成就相关
        public string[] GetLevelNodeAchievements(string levelNodeBusinessId)
        {
            var nodeCfg = Get<LevelsNodesCfgData>(levelNodeBusinessId);
            if (nodeCfg == null)
            {
                throw new Exception($"LevelNodeCfgData not found for businessId: {levelNodeBusinessId}");
            }
            return nodeCfg.AchievementUid.ToArray();
        }

        public string GetLevelNodeAchievementDescLid(string achievementBusinessId)
        {
            var achievementCfg = Get<AchievementsCfgData>(achievementBusinessId);
            if (achievementCfg == null)
            {
                throw new Exception($"AchievementCfgData not found for businessId: {achievementBusinessId}");
            }
            return achievementCfg.Desc;
        }

        public float[] GetLevelNodeAchievementArgs(string achievementBusinessId)
        {
            var achievementCfg = Get<AchievementsCfgData>(achievementBusinessId);
            if (achievementCfg == null)
            {
                throw new Exception($"AchievementCfgData not found for businessId: {achievementBusinessId}");
            }
            return achievementCfg.Args.ToArray();
        }

        public string GetLevelNodeAchievementRewards(string achievementBusinessId)
        {
            var achievementCfg = Get<AchievementsCfgData>(achievementBusinessId);
            if (achievementCfg == null)
            {
                throw new Exception($"AchievementCfgData not found for businessId: {achievementBusinessId}");
            }
            return achievementCfg.RewardUid;
        }

        public List<int> GetLevelNodeAchievementRewardCurrenciesBusinessIds(string achievementBusinessId)
        {
            var rewardUid = GetLevelNodeAchievementRewards(achievementBusinessId);
            var rewardCfg = Get<RewardsCfgData>(rewardUid);
            if (rewardCfg == null)
            {
                throw new Exception($"RewardCfgData not found for businessId: {rewardUid}");
            }
            return rewardCfg.Currencies;
        }

        public List<int> GetLevelNodeAchievementRewardCurrenciesCount(string achievementBusinessId)
        {
            var rewardUid = GetLevelNodeAchievementRewards(achievementBusinessId);
            var rewardCfg = Get<RewardsCfgData>(rewardUid);
            if (rewardCfg == null)
            {
                throw new Exception($"RewardCfgData not found for businessId: {rewardUid}");
            }
            return rewardCfg.CurrenciesCount;
        }

        public List<string> GetLevelNodeAchievementRewardItemsBusinessIds(string achievementBusinessId)
        {
            var rewardUid = GetLevelNodeAchievementRewards(achievementBusinessId);
            var rewardCfg = Get<RewardsCfgData>(rewardUid);
            if (rewardCfg == null)
            {
                throw new Exception($"RewardCfgData not found for businessId: {rewardUid}");
            }
            return rewardCfg.Items;
        }

        public List<int> GetLevelNodeAchievementRewardItemsCount(string achievementBusinessId)
        {
            var rewardUid = GetLevelNodeAchievementRewards(achievementBusinessId);
            var rewardCfg = Get<RewardsCfgData>(rewardUid);
            if (rewardCfg == null)
            {
                throw new Exception($"RewardCfgData not found for businessId: {rewardUid}");
            }
            return rewardCfg.ItemsCount;
        }

        #endregion

        #region 对话相关
        public List<DialogsCfgData> GetDialogDatas(int groupId)
        {
            var dialogDataList = new List<DialogsCfgData>();
            var allDialogDatas = GetAll<DialogsCfgData>();
            foreach (var dialogData in allDialogDatas)
            {
                if (dialogData.GroupId == groupId)
                {
                    dialogDataList.Add(dialogData);
                }
            }
            return dialogDataList;
        }
        #endregion

        #region 引导相关
        public string GetNextGuideStepBusinessId(string guideBusinessId)
        {
            var curId = int.Parse(guideBusinessId);
            var nextId = curId + 1;
            return nextId.ToString();
        }

        public string GetFingerIconPath()
        {
            return jConfigManager.Get<PrefabsCfgData>("2000").PrefabName;
        }

        public string GetFingerSwipeIconPath()
        {
            return jConfigManager.Get<PrefabsCfgData>("2001").PrefabName;
        }

        #endregion

        #region Entrance相关
        public string GetEntranceIconPath(string businessId)
        {
            if(businessId == "3") //布阵
            {
                var textureCfg = jConfigManager.Get<TexturesCfgData>("1302");
                return textureCfg.Path;
            }

            return null;
        }

        #endregion

        #region 公式相关-前后端要保持一致
        /// <summary>
        /// 计算最大血量
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public int GetFormulaMaxHpByLevel(int level)
        {
            return (int)(1000 * (1 + level / 10f)); //to do: 计算最大HP
        }

        /// <summary>
        /// 根据经验值计算等级
        /// </summary>
        /// <param name="experience"></param>
        /// <returns></returns>
        public int GetFormulaLevel(int totalExp)
        {
            return ExpCalculator.GetLevelByTotalExp(totalExp);
        }


        public int GetFormulaLevelUpExperience(int level)
        {
            return ExpCalculator.GetLevelUpExp(level);
        }







        #endregion


    }

}

