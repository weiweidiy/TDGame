using Adic;
using EnhancedScrollerAdvance;
using Game.Common;
using Game.Share;
using JFramework;
using JFramework.Game.View;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Event = JFramework.Event;


namespace Tiktok
{
    public class UILevelNodeDetailController : ViewController
    {
        //public class Open : Event { }
        //public class UIControllerEventAttackClicked : Event { }
        public class EventPanelShowed : Event { }


        public class ControllerArgs : ControllerBaseArgs
        {
            public UIPanelLevelNodeDetail panel;
            public LevelNodeDTO dto;
        }

        //[Inject]
        //UIManager uiManager;

        [Inject]
        TiktokConfigManager configManager;

        [Inject]
        TiktokSpritesManager spritesManager;

        [Inject]
        ILanguageManager languageManager;

        UIPanelLevelNodeEntranceProperties properties;

        public UILevelNodeDetailController(EventManager eventManager) : base(eventManager)
        {
        }

        public override void OnStart()
        {
            base.OnStart();
            eventManager.AddListener<UIPanelEventCloseBtnClicked>(OnPanelCloseBtnClicked);
            //eventManager.AddListener<UIPanelLevelNodeDetail.EventEnterLevelNodeClicked>(OnPanelEnterLevelNodeBtnClicked);
            eventManager.AddListener<UIPanelLevelNodeDetail.EventDeploySamuraiClicked>(OnPanelDeploySamuraiClicked);
        }

        public override void OnStop()
        {
            base.OnStop();
            eventManager.RemoveListener<UIPanelEventCloseBtnClicked>(OnPanelCloseBtnClicked);
           // eventManager.RemoveListener<UIPanelLevelNodeDetail.EventEnterLevelNodeClicked>(OnPanelEnterLevelNodeBtnClicked);
            eventManager.RemoveListener<UIPanelLevelNodeDetail.EventDeploySamuraiClicked>(OnPanelDeploySamuraiClicked);
        }

        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            var dto = controllerArgs.dto;

            properties = new UIPanelLevelNodeEntranceProperties();
            properties.levelNodeBusinessId = dto.BusinessId;
            properties.dataDeployList = ConvertToScrollerDataList(configManager.GetLevelNodeFormation(dto.BusinessId));
            properties.dataAchievementList = ConvertAchievementsToScrollerDataList(configManager.GetLevelNodeAchievements(dto.BusinessId), dto.Process);
            var panelController = uiManager.ShowPanel(controllerArgs.panelName, properties);

            var uiArg = new ControllerArgs();
            uiArg.panel =  panelController as UIPanelLevelNodeDetail;
            uiArg.dto = dto;
            SendEvent<EventPanelShowed>(uiArg);
        }

        #region panel交互事件
        private void OnPanelCloseBtnClicked(UIPanelEventCloseBtnClicked e)
        {
            var panelData = e.Body as UIPanelLevelNodeDetail.UIPanelLevelNodeDetailPanelData;
            if(panelData == null)
            {
                return;
            }
            var panel = panelData.panel;
            uiManager.HidePanel(panel.ScreenId);
        }

        //private void OnPanelEnterLevelNodeBtnClicked(UIPanelLevelNodeDetail.EventEnterLevelNodeClicked e)
        //{
        //    var panel = e.Body as UIPanelLevelNodeDetail.BasePanelData;
        //    uiManager.HidePanel(panel.panel.ScreenId);
        //    //SendEvent<UIControllerEventAttackClicked>(panel.levelNodeBusinessId);
        //}

        private void OnPanelDeploySamuraiClicked(UIPanelLevelNodeDetail.EventDeploySamuraiClicked e)
        {
            var levelNodeUnitBusinessId = e.Body as string;
            properties.RefreshSamuraiInfo(CreateLevelNodeUnitInfo(levelNodeUnitBusinessId));
        }

        #endregion

        private List<EnhancedDataV2> ConvertToScrollerDataList(string[] units)
        {
            var result = new List<EnhancedDataV2>();

            for (int i = 0; i < units.Length; i++)
            {
                var uid = units[i];
                if (string.IsNullOrEmpty(uid))
                {
                    units[i] = null;
                }

                result.Add(CreateDeployData(i, uid));
            }
            return result;
        }

        private List<EnhancedDataV2> ConvertAchievementsToScrollerDataList(string[] achievements, int process)
        {
            var result = new List<EnhancedDataV2>();
            for (int i = 0; i < achievements.Length; i++)
            {
                var achievementBusinessId = achievements[i];
                var data = new EnhancedDataV2();
                var unitData = new UIAchievementScrollerUnitView.UnitData();
                unitData.desc = i > process? "??????" : GetAchievementDesc(achievementBusinessId);
                unitData.resourceDetailInfos = GetResourceDetailInfos(achievementBusinessId);
                unitData.isAchieved = i < process;
                data.UnitData = unitData;
                result.Add(data);
            }
            return result;
        }

        private List<ResourceDetailInfo> GetResourceDetailInfos(string achievementBusinessId)
        {
            var result = new List<ResourceDetailInfo>();

            var currencies = configManager.GetLevelNodeAchievementRewardCurrenciesBusinessIds(achievementBusinessId);
            var currenciesCount = configManager.GetLevelNodeAchievementRewardCurrenciesCount(achievementBusinessId);
            //检查currencies和currenciesCount 2个列表的长度是否相同
            if (currencies.Count != currenciesCount.Count)
                throw new Exception("成就奖励的货币配置长度不一致 成就id:" + achievementBusinessId);

            var items = configManager.GetLevelNodeAchievementRewardItemsBusinessIds(achievementBusinessId);
            var itemsCount = configManager.GetLevelNodeAchievementRewardItemsCount(achievementBusinessId);
            if(items.Count != itemsCount.Count)
                throw new Exception("成就奖励的道具配置长度不一致 成就id:" + achievementBusinessId);

            //货币奖励
            if (currencies != null && currencies.Count > 0)
            {
                for(int i = 0; i < currencies.Count; i ++)
                {
                    var currency = (CurrencyType)currencies[i];
                    if(currency == CurrencyType.None)
                        continue;

                    var count = currenciesCount[i];
                    var detailInfo = new ResourceDetailInfo();
                    detailInfo.icon =  spritesManager.GetSprite(configManager.GetCurrencySmallIconPath(((int)currency).ToString()));
                    result.Add(detailInfo);

                }
            }

            //道具奖励
            if (items != null && items.Count > 0)
            {   
                for (int i = 0; i < items.Count; i++)
                {
                    var itemBusinessId = items[i];
                    if (itemBusinessId == "0")
                        continue;

                    var count = itemsCount[i];
                    var detailInfo = new ResourceDetailInfo();
                    result.Add(detailInfo);
                }
            }

            return result;
        }

        string GetAchievementDesc(string achievementBusinessId)
        {
            var args = configManager.GetLevelNodeAchievementArgs(achievementBusinessId);
            var count = args.Length;
            var desc = languageManager.GetText(configManager.GetLevelNodeAchievementDescLid(achievementBusinessId));
            switch (count)
            {
                case 0:
                    return desc;
                case 1:
                    return desc.FormatPercent(args[0]);
                case 2:
                    return desc.FormatPercent(args[0], args[1]);
                case 3:
                    return desc.FormatPercent(args[0], args[1], args[2]);
                default:
                    Debug.LogError($"GetAchievementDesc args count exceed 3, achievementBusinessId: {achievementBusinessId}");
                    break;
            }
            return desc;
        }


        EnhancedDataV2 CreateDeployData(int index, string levelNodeUnitBusinessId)
        {
            var data = new EnhancedDataV2();
            var unitData = new UIDeployScrollerUnitView.UnitData();
            unitData.valid = true;
            unitData.businessId = levelNodeUnitBusinessId;
            unitData.spHead = levelNodeUnitBusinessId != "0" ? spritesManager.GetSprite(configManager.GetLevelNodeUnitSamuraiHeadSpriteBusinessId(levelNodeUnitBusinessId)) : null;
            data.UnitData = unitData;

            return data;
        }

        private SamuraiDetailInfo CreateLevelNodeUnitInfo(string levelNodeUnitBusinessId)
        {
            var result = new SamuraiDetailInfo();

            result.power = configManager.GetLevelNodeUnitPower(levelNodeUnitBusinessId);
            result.def = configManager.GetLevelNodeUnitDef(levelNodeUnitBusinessId);
            result.intel = configManager.GetLevelNodeUnitIntel(levelNodeUnitBusinessId);
            result.speed = configManager.GetLevelNodeUnitSpeed(levelNodeUnitBusinessId);
            result.level = configManager.GetLevelNodeUnitLevel(levelNodeUnitBusinessId);
            result.attack = configManager.GetLevelNodeUnitAttack(levelNodeUnitBusinessId);
            result.defence = configManager.GetLevelNodeUnitDefence(levelNodeUnitBusinessId);
            result.hp = configManager.GetLevelNodeUnitHp(levelNodeUnitBusinessId);
            result.maxHp = configManager.GetLevelNodeUnitHp(levelNodeUnitBusinessId);
            result.soldierName = languageManager.GetText(configManager.GetLevelNodeUnitSoldierNameLid(levelNodeUnitBusinessId));
            result.name = languageManager.GetText(configManager.GetLevelNodeUnitSamuraiNameLid(levelNodeUnitBusinessId));

            return result;
        }       
    }
}
