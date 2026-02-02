using Adic;
using Game.Common;
using JFramework;
using JFramework.Game.View;
using System;


namespace Tiktok
{
    public class UILoginController : ViewController
    {
        //public class Open : Event { }
        public class EventEnterGame : Event { }

        public class ControllerArgs : ControllerBaseArgs
        {
            //登录界面不需要额外参数
        }

        //[Inject]
        //UIManager uiManager;
        public UILoginController(EventManager eventManager) : base(eventManager)
        {
        }
        public override void OnStart()
        {
            base.OnStart();
            eventManager.AddListener<UIPanelLogin.EventBtnEnterClick>(OnPanelEnterClicked);
        }

        public override void OnStop()
        {
            base.OnStop();
            eventManager.RemoveListener<UIPanelLogin.EventBtnEnterClick>(OnPanelEnterClicked);
        }

        private void OnPanelEnterClicked(UIPanelLogin.EventBtnEnterClick e)
        {
            SendEvent<EventEnterGame>(this);
        }

        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            var properties = new UIPanelLoginProperties();
            uiManager.ShowPanel(controllerArgs.panelName, properties);
        }
    }
}
