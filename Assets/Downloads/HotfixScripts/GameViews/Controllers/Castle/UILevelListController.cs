using Adic;
using Game.Common;
using Game.Share;
using JFramework;
using JFramework.Game.View;
using System;
using System.Collections.Generic;


namespace Tiktok
{
    public class UILevelListController : ViewController
    {
        public class EventCellClicked : JFramework.Event { }

        [Inject]
        UIScrollerUnitViewDataConverter dataConverter;

        [Inject]
        public UILevelListController(EventManager eventManager) : base(eventManager)
        {
        }

        public class ControllerArgs : ControllerBaseArgs
        {
            public List<LevelNodeDTO> levelNodeDTOs;
        }


        public override void OnStart()
        {
            base.OnStart();
            //eventManager.AddListener<Open>(OnOpenKacha);
            eventManager.AddListener<UIPanelEventCloseBtnClicked>(OnClose);
            eventManager.AddListener<UIPanelLevelList.EventCellClicked>(OnCellClicked);
        }


        public override void OnStop()
        {
            base.OnStop();
            //eventManager.RemoveListener<Open>(OnOpenKacha);
            eventManager.RemoveListener<UIPanelEventCloseBtnClicked>(OnClose);
            eventManager.RemoveListener<UIPanelLevelList.EventCellClicked>(OnCellClicked);
        }



        private void OnClose(UIPanelEventCloseBtnClicked e)
        {
            var panelData = e.Body as UIPanelLevelList.UIPanelLevelListPanelData;
            if (panelData == null)
            {
                return;
            }
            var panel = panelData.panel;
            uiManager.HidePanel(panel.ScreenId);
        }

        private void OnCellClicked(UIPanelLevelList.EventCellClicked e)
        {
            SendEvent<EventCellClicked>(e.Body);
        }

        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            //var samuraisModel = e.Body as SamuraisModel;
            var LevelListProperties = new UIPanelLevelListProperties();
            LevelListProperties.dataLevelList = dataConverter.Convert(controllerArgs.levelNodeDTOs);
            var screenId = uiManager.ShowPanel(nameof(UIPanelLevelList), LevelListProperties);
        }

        protected override void DoClose(Close e)
        {
            base.DoClose(e);
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            uiManager.HidePanel(controllerArgs.panelName);
        }
    }
}
