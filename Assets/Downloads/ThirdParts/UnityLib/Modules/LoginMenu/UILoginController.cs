using Adic;
using Game.Common;
using JFramework;


namespace Game.Modules
{
    public class UILoginController : ViewController
    {
        //public class Open : Event { }
        public class EventEnterGame : Event { }

        public class ControllerArgs : ControllerBaseArgs
        {
            //登录界面不需要额外参数
        }

        UIPanelLoginProperties properties;

        //[Inject]
        //UIManager uiManager;
        [Inject]
        public UILoginController(EventManager eventManager, UIManager uiManager) : base(eventManager, uiManager)
        {
        }
        public override void OnStart()
        {
            base.OnStart();
            //eventManager.AddListener<UIPanelLogin.EventBtnEnterClick>(OnPanelEnterClicked);
        }

        public override void OnStop()
        {
            base.OnStop();
           // eventManager.RemoveListener<UIPanelLogin.EventBtnEnterClick>(OnPanelEnterClicked);
        }

        //private void OnPanelEnterClicked(UIPanelLogin.EventBtnEnterClick e)
        //{
        //    SendEvent<EventEnterGame>(this);
        //}

        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            properties = new UIPanelLoginProperties();
            uiManager.ShowPanel(controllerArgs.panelName, properties);
            properties.onClick += Properties_onClick;
        }

        protected override void DoClose(Close e)
        {
            base.DoClose(e);

            properties.onClick -= Properties_onClick;
        }

        private void Properties_onClick(UIPanelLogin.UIPanelLoginPanelData obj)
        {
            SendEvent<EventEnterGame>(this);
        }


    }
}
