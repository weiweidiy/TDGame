using Adic;
using Game.Common;
using JFramework;
using JFramework.Game.View;
using System;
using UnityEngine;
using Event = JFramework.Event;



namespace Game.Modules
{
    public class UIWarningMessageController : ViewController
    {
        public enum WarningType
        {
            Normal,
            Error,
            MsgBox
        }

        //public class Open : Event { }

        public class ControllerArgs : ControllerBaseArgs
        {
            public string Message;
            public WarningType Type;
        }

        //[Inject]
        //UIManager uiManager;

        public UIWarningMessageController(EventManager eventManager,UIManager uiManager) : base(eventManager, uiManager)
        {
        }

        public override void OnStart()
        {
            base.OnStart();
            eventManager.AddListener<UIPanelEventCloseBtnClicked>(OnBtnCloseClicked);
        }

        public override void OnStop()
        {
            base.OnStop();
            eventManager.RemoveListener<UIPanelEventCloseBtnClicked>(OnBtnCloseClicked);
        }

        private void OnBtnCloseClicked(UIPanelEventCloseBtnClicked e)
        {
            var panelData = e.Body as UIPanelWarningMessage.UIPanelWarningMessagePanelData;
            if (panelData == null) return;

            var panel = panelData.panel;
            uiManager.HidePanel(panel.ScreenId);
        }


        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if(controllerArgs == null) return;

            //ShowError(controllerArgs.Message);

            var properties = new UIPanelWarningMessageProperties
            {
                message = controllerArgs.Message,
            };
            uiManager.ShowPanel(controllerArgs.panelName, properties);
        }

        //void ShowError(string msg)
        //{

        //}
    }
}
