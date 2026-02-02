using Adic;
using Game.Common;
using JFramework;
using JFramework.Game.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;



namespace Tiktok
{
    public class UIDialogController : ViewController
    {
        public class ControllerArgs : ControllerBaseArgs
        {
            public int DialogGroupId;
            public List<BaseDialogPlayer.DialogData> DataList;
        }
        //public class Open : Event { }
        public class EventDialogCompleted:Event { }
        //[Inject]
        //UIManager uiManager;
        public UIDialogController(EventManager eventManager) : base(eventManager)
        {
        }
        public override void OnStart()
        {
            base.OnStart();
            eventManager.AddListener<UIPanelDialog.EventDialogComplete>(OnDialogComplete);
        }

        public override void OnStop()
        {
            base.OnStop();
            eventManager.RemoveListener<UIPanelDialog.EventDialogComplete>(OnDialogComplete);
        }


        private void OnDialogComplete(UIPanelDialog.EventDialogComplete e)
        {
            var panelData = e.Body as UIPanelDialog.UIPanelDialogPanelData;
            if (panelData == null)
                return;

            var dialogGroupId = panelData.DialogGroupId;
            uiManager.HidePanel(nameof(UIPanelDialog));
            SendEvent<EventDialogCompleted>(dialogGroupId);
        }

        
        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            var properties = new UIPanelDialogProperties()
            {
                DialogGroupId = controllerArgs.DialogGroupId,
                DataList = controllerArgs.DataList
            };
            uiManager.ShowPanel(nameof(UIPanelDialog), properties);
        }
    }
}
