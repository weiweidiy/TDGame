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

    public class UICurrenciesController : ViewController
    {
        public class ControllerArgs : ControllerBaseArgs
        {

        }

        [Inject]
        CurrenciesModel currenciesModel;

        [Inject]
        HpPoolModel hpPoolModel;

        UIPanelCurrenciesProperties properties;

        public UICurrenciesController(EventManager eventManager) : base(eventManager)
        {
        }
        public override void OnStart()
        {
            base.OnStart();
            //显示货币UI
            ShowCurrenies();

            //注册事件
            eventManager.AddListener<CurrenciesModel.EventUpdate>(OnCurrenciesUpdate);
            eventManager.AddListener<HpPoolModel.EventUpdate>(OnHpPoolUpdate);
        }



        public override void OnStop()
        {
            base.OnStop();

            eventManager.RemoveListener<CurrenciesModel.EventUpdate>(OnCurrenciesUpdate);
        }
        void ShowCurrenies()
        {
            properties = new UIPanelCurrenciesProperties();
            var dto = currenciesModel.Get(CurrencyType.Coin.ToString());

            //获取货币数据
            properties.CurrencyDict.Add(CurrencyType.Coin, currenciesModel.Get(CurrencyType.Coin.ToString())?.Count ?? 0);
            properties.CurrencyDict.Add(CurrencyType.Pan, currenciesModel.Get(CurrencyType.Pan.ToString())?.Count ?? 0);
            //properties.Food = currenciesModel.Get(CurrencyType.Food.ToString())?.Count ?? 0;
            properties.ProgressData = new ProgressData(){Current = hpPoolModel.Data.Hp , Max = hpPoolModel.Data.MaxHp };

            //需要显示的货币类型
            properties.menuItems = new List<CurrencyType>()
            {
                CurrencyType.Coin,
                CurrencyType.Pan
            };

            //显示底部按钮栏
            uiManager.ShowPanel(nameof(UIPanelCurrencies), properties);
        }

        /// <summary>
        /// HP更新了
        /// </summary>
        /// <param name="e"></param>
        private void OnHpPoolUpdate(HpPoolModel.EventUpdate e)
        {
            var dto = e.Body as HpPoolDTO;
            if (dto == null)
            {
                Debug.LogError("OnHpPoolUpdate dto is null");
                return;
            }

            if (properties == null)
                return;

            properties.ProgressData= new ProgressData() { Current = dto.Hp, Max = dto.MaxHp };
            properties.Refresh();
            
        }

        /// <summary>
        /// 货币更新了
        /// </summary>
        /// <param name="e"></param>
        private void OnCurrenciesUpdate(CurrenciesModel.EventUpdate e)
        {
            var dto = e.Body as List<CurrencyDTO>;
            if (dto == null)
            {
                Debug.LogError("OnCurrenciesUpdate dto is null");
                return;
            }

            if (properties == null)
                return;

            //刷新UI
            foreach (var item in dto)
            {
                var type = item.CurrencyType;
                var count = item.Count;

                if(properties.CurrencyDict.ContainsKey(type))
                    properties.CurrencyDict[type] = count;
                else
                    properties.CurrencyDict.Add(type,count);
            }
            properties.Refresh();

        }

        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if(controllerArgs == null) return;
        }
    }
}
