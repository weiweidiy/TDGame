using Adic;
using Game.Common;
using JFramework;
using JFramework.Game.View;
using System;
using System.Collections.Generic;
using UnityEngine;
using Event = JFramework.Event;


namespace Tiktok
{
    public class UIBuildingMenuController : ViewController
    {
        public class EventBuildingPopupMenuClicked : Event { }

        public class ControllerArgs : ControllerBaseArgs
        {
            public List<UIPanelBuildingMenus.UIBuildingMenu> menuTypes;
            public Vector3 worldPosition;
            public string businessId;
            public UIPanelBuildingMenus.UIBuildingMenu clickedMenu;
        }

        ControllerArgs curOpenData;

        public UIBuildingMenuController(EventManager eventManager) : base(eventManager)
        {
        }

        public override void OnStart()
        {
            base.OnStart();
            eventManager.AddListener<UIPanelBuildingMenus.UIPanelEventMenuClicked>(DoMenuClicked);
            eventManager.AddListener<UIPanelEventCloseBtnClicked>(DoMenuClosed);
        }



        public override void OnStop()
        {
            base.OnStop();
            eventManager.RemoveListener<UIPanelBuildingMenus.UIPanelEventMenuClicked>(DoMenuClicked);
            eventManager.RemoveListener<UIPanelEventCloseBtnClicked>(DoMenuClosed);
        }

        private void DoMenuClicked(UIPanelBuildingMenus.UIPanelEventMenuClicked e)
        {
            var panelData = e.Body as UIPanelBuildingMenus.UIPanelBuildingMenusPanelData;
            if (panelData == null) return;

            uiManager.HidePanel(panelData.panel.ScreenId);

            var menuKey = panelData.menuItem.Key;
            var businessId = curOpenData.businessId;
            curOpenData.clickedMenu = menuKey;

            SendEvent<EventBuildingPopupMenuClicked>(curOpenData);
            curOpenData = null;
        }

        private void DoMenuClosed(UIPanelEventCloseBtnClicked e)
        {
            var panelData = e.Body as UIPanelBuildingMenus.UIPanelBuildingMenusPanelData;
            if (panelData == null) return;

            uiManager.HidePanel(panelData.panel.ScreenId);
            curOpenData = null;
        }

        protected override void DoOpen(Open e)
        {
            curOpenData = e.Body as ControllerArgs;
            if (curOpenData == null) return;
  
            var properties = new UIPanelBuildingMenusProperties()
            {
                menuItems = curOpenData.menuTypes,
                worldPosition = curOpenData.worldPosition
            };
            uiManager.ShowPanel(curOpenData.panelName, properties);
        }
    }
}
