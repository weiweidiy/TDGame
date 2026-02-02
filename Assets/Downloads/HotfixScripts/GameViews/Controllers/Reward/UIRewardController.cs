using Adic;
using EnhancedScrollerAdvance;
using Game.Common;
using Game.Share;
using JFramework;
using JFramework.Game.View;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Event = JFramework.Event;



namespace Tiktok
{
    public class UIRewardController : ViewController
    {
        public enum RewardShowType
        {
            Combat,
            Common,
        }

        public class CommonRewardData
        {
            public SystemType DataType { get; set; }
            public string BusinessId { get; set; }
            public int Count { get; set; }
        }

        public class CommonRewardArgs
        {
            public List<CommonRewardData> Rewards { get; set; } = new List<CommonRewardData>();
        }

        /// <summary>
        /// 奖励ui数据参数
        /// </summary>
        public class CombatRewardArgs
        {
            public List<List<CommonRewardData>> Rewards { get; set; } = new List<List<CommonRewardData>>();
        }

        /// <summary>
        /// 公开的打开奖励界面事件
        /// </summary>
        public class OpenCombatReward : Event { }

        public class OpenCommonReward : Event { }

        /// <summary>
        /// 领取的奖励
        /// </summary>
        public class EventCombatRewardReceived : Event { }

        public class EventCommonRewardReceived : Event { }

        /// <summary>
        /// 奖励播放完毕了
        /// </summary>
        public class EventRewardComplete : Event { }


        //[Inject]
        //UIManager uiManager;

        [Inject]
        TiktokConfigManager configManager;

        [Inject]
        IAssetsLoader assetsLoader;


        List<List<CommonRewardData>> curRewardDatas;

        /// <summary>
        /// 缓存的奖励数据
        /// </summary>
        Queue<KeyValuePair<RewardShowType, List<List<CommonRewardData>>>> cacheRewards = new Queue<KeyValuePair<RewardShowType, List<List<CommonRewardData>>>>();

        /// <summary>
        /// 是否正在显示奖励界面
        /// </summary>
        bool isShowing = false;


        public UIRewardController(EventManager eventManager) : base(eventManager)
        {
        }

        public override void OnStart()
        {
            base.OnStart();
            eventManager.AddListener<OpenCombatReward>(OnOpenCombatReward);
            eventManager.AddListener<OpenCommonReward>(OnOpenCommonReward);
            eventManager.AddListener<UIPanelEventCloseBtnClicked>(OnCommonRewardCloseBtnClicked);
            eventManager.AddListener<UIPanelEventCloseBtnClicked>(OnCombatRewardCloseBtnClicked);

        }



        public override void OnStop()
        {
            base.OnStop();
            cacheRewards.Clear();

            eventManager.RemoveListener<OpenCombatReward>(OnOpenCombatReward);
            eventManager.RemoveListener<OpenCommonReward>(OnOpenCommonReward);
            eventManager.RemoveListener<UIPanelEventCloseBtnClicked>(OnCommonRewardCloseBtnClicked);
            eventManager.RemoveListener<UIPanelEventCloseBtnClicked>(OnCombatRewardCloseBtnClicked);
        }



        /// <summary>
        /// 通用奖励框关闭按钮被点击时的事件处理
        /// </summary>
        /// <param name="e"></param>
        private void OnCommonRewardCloseBtnClicked(UIPanelEventCloseBtnClicked e)
        {
            var panelData = e.Body as UIPanelCommonReward.UIPanelCommonRewardPanelData;
            if (panelData == null) return;

            var panel = panelData.panel;
            uiManager.HidePanel(panel.ScreenId);

            SendEvent<EventCommonRewardReceived>(curRewardDatas);

            //显示下一个奖励
            ShowNextReward();
        }

        /// <summary>
        /// 战斗奖励框关闭按钮被点击时的事件处理
        /// </summary>
        /// <param name="e"></param>
        private void OnCombatRewardCloseBtnClicked(UIPanelEventCloseBtnClicked e)
        {
            var panelData = e.Body as UIPanelCombatReward.UIPanelCombatRewardPanelData;
            if (panelData == null) return;

            var panel = panelData.panel;
            uiManager.HidePanel(panel.ScreenId);

            SendEvent<EventCombatRewardReceived>(curRewardDatas);

            //显示下一个奖励
            ShowNextReward();
        }

        #region 外部事件响应
        private void OnOpenCombatReward(OpenCombatReward e)
        {
            var args = e.Body as CombatRewardArgs;
            var rewardData = args.Rewards;

            //缓存奖励
            cacheRewards.Enqueue(new KeyValuePair<RewardShowType, List<List<CommonRewardData>>>(RewardShowType.Combat, rewardData));

            //如果当前没有显示奖励界面，则显示下一个奖励
            if (!isShowing)
            {
                ShowNextReward();
            }
        }

        private void OnOpenCommonReward(OpenCommonReward e)
        {
            var arg = e.Body as CommonRewardArgs;
            var rewardData = arg.Rewards;
            var lst = new List<List<CommonRewardData>>();
            lst .Add(rewardData);
            //Debug.Log("收到通用奖励请求，奖励数量 " + rewards.Count);
            //缓存奖励
            cacheRewards.Enqueue(new KeyValuePair<RewardShowType, List<List<CommonRewardData>>>(RewardShowType.Combat, lst));

            //如果当前没有显示奖励界面，则显示下一个奖励
            if (!isShowing)
            {
                ShowNextReward();
            }

        }

        #endregion

        private async Task ShowNextReward()
        {
            if (cacheRewards.Count > 0)
            {
                isShowing = true;
                var reward = cacheRewards.Dequeue();
                var rewardType = reward.Key;
                curRewardDatas = reward.Value;
                switch (rewardType)
                {
                    case RewardShowType.Common:
                        {
                            var uiProperties = new UIPanelCommonRewardProperties
                            {
                                dataList = await ConvertToScrollerDataList(curRewardDatas[0])
                            };
                            uiManager.ShowPanel(nameof(UIPanelCommonReward), uiProperties);
                        }
                        break;
                    case RewardShowType.Combat:
                        {
                            var maxCount = curRewardDatas.Count;
                            var winRewardDatas = curRewardDatas[0];
                            var achievementRewardDTOs = maxCount > 1 ? curRewardDatas[1] : null;

                            var uiProperties = new UIPanelCombatRewardProperties
                            {
                                winDataList = winRewardDatas != null ? await ConvertToScrollerDataList(winRewardDatas) : null,
                                achievementDataList = achievementRewardDTOs != null ? await ConvertToScrollerDataList(achievementRewardDTOs) : null,
                            };
                            uiManager.ShowPanel(nameof(UIPanelCombatReward), uiProperties);
                        }

                        break;
                    default:
                        //未知奖励类型，抛异常
                        throw new ArgumentOutOfRangeException("没有处理的奖励类型 " + reward.Key);
                }
            }
            else
            {
                isShowing = false;
                Debug.Log("所有奖励已播放完毕");
                SendEvent<EventRewardComplete>(null);
            }

        }

        async Task<List<EnhancedDataV2>> ConvertToScrollerDataList(List<CommonRewardData> rewardDatas)
        {
            var dataList = new List<EnhancedDataV2>();

            foreach (var data in rewardDatas)
            {
                switch (data.DataType)
                {
                    case SystemType.Currency:
                        {
                            var iconPath = configManager.GetCurrencyBigIconPath(data.BusinessId);
                            var spIcon = await assetsLoader.LoadAssetAsync<Sprite>(iconPath);
                            var unitData = new UIRewardScrollerUnitView.UnitData();
                            unitData.count = data.Count;
                            unitData.spIcon = spIcon;
                            var dataV2 = new EnhancedDataV2();
                            dataV2.UnitData = unitData;
                            dataList.Add(dataV2);
                        }
                        break;
                    case SystemType.Samurai:
                        {
                            var iconPath = configManager.GetSamuraiHeadIconBusinessId(data.BusinessId);
                            var spIcon = await assetsLoader.LoadAssetAsync<Sprite>(iconPath);
                            var unitData = new UIRewardScrollerUnitView.UnitData();
                            unitData.count = data.Count;
                            unitData.spIcon = spIcon;
                            var dataV2 = new EnhancedDataV2();
                            dataV2.UnitData = unitData;
                            dataList.Add(dataV2);
                        }
                        break;
                    case SystemType.Deploy:
                        {
                            var iconPath = configManager.GetEntranceIconPath(data.BusinessId);
                            var spIcon = await assetsLoader.LoadAssetAsync<Sprite>(iconPath);
                            var unitData = new UIRewardScrollerUnitView.UnitData();
                            unitData.count = data.Count;
                            unitData.spIcon = spIcon;
                            var dataV2 = new EnhancedDataV2();
                            dataV2.UnitData = unitData;
                            dataList.Add(dataV2);
                        }
                        break;
                    case SystemType.Item:
                        {
                        }
                        break;
                }
            }

            //var currencies = rewardDTO.Currencies;
            //var items = rewardDTO.BagItems;
            ////如果currencies和items都为空，则不需要显示奖励
            //if ((currencies == null || currencies.Count == 0) && (items == null || items.Count == 0))
            //{
            //    return dataList;
            //}

            ////如果有货币奖励
            //if (currencies != null && currencies.Count > 0)
            //{
            //    foreach (var currency in currencies)
            //    {
            //        var iconPath = configManager.GetCurrencyBigIconPath(((int)currency.CurrencyType).ToString());
            //        var spIcon = await assetsLoader.LoadAssetAsync<Sprite>(iconPath);
            //        var unitData = new UIRewardScrollerUnitView.UnitData();
            //        unitData.count = currency.Count;
            //        unitData.spIcon = spIcon;
            //        var data = new EnhancedDataV2();
            //        data.UnitData = unitData;
            //        dataList.Add(data);
            //    }
            //}

            ////如果有物品奖励
            //if (items != null && items.Count > 0)
            //{
            //    foreach (var item in items)
            //    {
            //        var data = new EnhancedDataV2
            //        {

            //        };
            //        dataList.Add(data);
            //    }
            //}

            return dataList;
        }

        protected override void DoOpen(Open e)
        {
            //throw new NotImplementedException();
        }
    }
}
