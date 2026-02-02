using Adic;
using Game.Common;
using Game.Share;
using JFramework;
using System;
using System.Collections.Generic;
using UnityEngine;



namespace Tiktok
{
    public class EventIntercepter : ViewController
    {
        [Inject]
        public EventIntercepter(EventManager eventManager) : base(eventManager)
        {
        }

        public override void OnStart()
        {
            base.OnStart();
            eventManager.AddListener<EventRequestCombat>(OnEventRequestCombat);
        }

        public override void OnStop()
        {
            base.OnStop();
            eventManager.RemoveListener<EventRequestCombat>(OnEventRequestCombat);
        }

        //List<CurrencyDTO> body;
        private void OnEventRequestCombat(EventRequestCombat e)
        {
            //拦截货币更新事件
            eventManager.AddListener<CurrenciesModel.EventUpdate>(OnCurrenciesUpdate); //战斗请求时，不更新货币
        }

        private void OnCurrenciesUpdate(CurrenciesModel.EventUpdate e)
        {
            e.Handled = true;
        }

        protected override void DoOpen(Open e)
        {
            //throw new NotImplementedException();
        }
    }
}
