using Adic;
using Game.Common;
using Game.Share;
using JFramework;
using JFramework.Game.View;
using System;
using System.Collections.Generic;
using UnityEngine;




namespace Tiktok
{
    public class GameLevelCombatResultController : ViewController
    {
        //public class Open : JFramework.Event { }

        public class ControllerArgs : ControllerBaseArgs
        {
            public ResponseFight RespFight;
        }

        ResponseFight respFight;

        [Inject]
        CurrenciesModel currenciesModel;

        [Inject]
        LevelsModel levelModel;

        public GameLevelCombatResultController(EventManager eventManager) : base(eventManager)
        {
        }
        public override void OnStart()
        {
            base.OnStart();
            //eventManager.AddListener<Open>(OnGameSceneCombatResult);
            eventManager.AddListener<UIRewardController.EventCombatRewardReceived>(OnCombatRewardReceived);
        }



        public override void OnStop()
        {
            base.OnStop();
            //eventManager.RemoveListener<Open>(OnGameSceneCombatResult);
            eventManager.RemoveListener<UIRewardController.EventCombatRewardReceived>(OnCombatRewardReceived);
        }



        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;


            eventManager.AddListener<UIRewardController.EventRewardComplete>(OnRewardComplete);

            respFight = controllerArgs.RespFight;

            var uiArg = new UIRewardController.CombatRewardArgs();
            if (respFight.WinRewardDTO != null)
            {
                var lst = new List<UIRewardController.CommonRewardData>();
                lst.AddRange(ConvertToRewardData(respFight.WinRewardDTO));
                uiArg.Rewards.Add(lst);
            }
                

            if (respFight.AchievementRewardDTO != null)
            {
                var lst = new List<UIRewardController.CommonRewardData>();
                lst.AddRange(ConvertToRewardData(respFight.AchievementRewardDTO));
                uiArg.Rewards.Add(lst);
            }

            //播放奖励
            if (uiArg.Rewards.Count > 0)
                SendEvent<UIRewardController.OpenCombatReward>(uiArg); 
        }

        private List<UIRewardController.CommonRewardData> ConvertToRewardData(RewardDTO winRewardDTO)
        {
            var result = new List<UIRewardController.CommonRewardData>();

            if(winRewardDTO.Currencies != null)
            {
                foreach (var currency in winRewardDTO.Currencies)
                {
                    var rewardData = new UIRewardController.CommonRewardData
                    {
                        DataType = SystemType.Currency,
                        BusinessId = ((int)currency.CurrencyType).ToString(),
                        Count = currency.Count
                    };
                    result.Add(rewardData);
                }
            }

            if (winRewardDTO.BagItems != null)
            {
                foreach (var item in winRewardDTO.BagItems)
                {
                    var rewardData = new UIRewardController.CommonRewardData
                    {
                        DataType = SystemType.Item,
                        BusinessId = item.ItemBusinessId,
                        Count = item.Count
                    };
                    result.Add(rewardData);
                }
            }
            return result;
        }



        private void OnCombatRewardReceived(UIRewardController.EventCombatRewardReceived e)
        {
            var allRewards = e.Body as List<List<UIRewardController.CommonRewardData>>;

            //将rewards中Currencies的count合并  BagItems合并 成一个RewardDTO
            var rewardDTO = new RewardDTO();
            rewardDTO.Currencies = new List<CurrencyDTO>();
            rewardDTO.BagItems = new List<ItemDTO>();
            foreach (var rewards in allRewards)
            {   
                foreach(var reward in rewards)
                {
                    switch(reward.DataType)
                    {
                        case SystemType.Currency:
                            {
                                var currencyType = (CurrencyType)int.Parse(reward.BusinessId);
                                var existingCurrency = rewardDTO.Currencies.Find(c => c.CurrencyType == currencyType);
                                if (existingCurrency != null)
                                {
                                    existingCurrency.Count += reward.Count;
                                }
                                else
                                {
                                    rewardDTO.Currencies.Add(new CurrencyDTO
                                    {
                                        CurrencyType = currencyType,
                                        Count = reward.Count
                                    });
                                }
                                break;
                            }
                        case SystemType.Item:
                            {
                                var existingItem = rewardDTO.BagItems.Find(i => i.ItemBusinessId == reward.BusinessId);
                                if (existingItem != null)
                                {
                                    existingItem.Count += reward.Count;
                                }
                                else
                                {
                                    rewardDTO.BagItems.Add(new ItemDTO
                                    {
                                        ItemBusinessId = reward.BusinessId,
                                        Count = reward.Count
                                    });
                                }
                                break;
                            }
                    }
                }
            }


            var currencies = rewardDTO.Currencies;
            foreach(var currency in currencies)
            {
                currenciesModel.AddCurrency(currency);
            }

            ////更新关卡节点
            //if (respFight != null && respFight.LevelNodeDTO != null)
            //    levelModel.UpdateNode(respFight.LevelNodeDTO);
        }

        /// <summary>
        /// 所有奖励播放完毕后，更新节点状态
        /// </summary>
        /// <param name="e"></param>
        private void OnRewardComplete(UIRewardController.EventRewardComplete e)
        {
            eventManager.RemoveListener<UIRewardController.EventRewardComplete>(OnRewardComplete);

            Debug.Log("OnRewardComplete");
            //更新关卡节点
            if (respFight.LevelNodeDTO != null)
                levelModel.UpdateNode(respFight.LevelNodeDTO);

            //if (respFight != null && respFight.Currencies != null)
            //    currenciesModel.UpdateCurrency(respFight.Currencies);

            //奖励播放完毕，如果有节点更新，这里更新节点状态
        }
    }
}
