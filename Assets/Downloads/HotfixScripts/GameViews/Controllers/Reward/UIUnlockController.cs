using Adic;
using Game.Common;
using JFramework;
using JFramework.Game.View;
using System;
using System.Collections.Generic;
using UnityEngine;
using static JFramework.Game.View.UIPanelMainMenu;
using Event = JFramework.Event;



namespace Tiktok
{
    public class UIUnlockController : ViewController
    {
        //public class Open : Event { }

        public class ControllerArgs : ControllerBaseArgs
        {
            public SystemType SystemType { get; set; }
            public string BusinessId { get; set; }
        }

        //[Inject]
        //UIManager uiManager;

        [Inject]
        TiktokConfigManager configManager;

        [Inject]
        TiktokSpritesManager spritesManager;

        [Inject]
        UIMainMenuController uiMainMenuController;

        ControllerArgs openArgs;

        public UIUnlockController(EventManager eventManager) : base(eventManager)
        {
        }

        public override void OnStart()
        {
            base.OnStart();
            eventManager.AddListener<UIPanelEventCloseBtnClicked>(OnPanelComplete);
        }

        public override void OnStop()
        {
            base.OnStop();
            eventManager.RemoveListener<UIPanelEventCloseBtnClicked>(OnPanelComplete);
        }

        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            openArgs = controllerArgs;

            var systemType = openArgs.SystemType;
            var businessId = openArgs.BusinessId;

            var properties = new UIPanelUnlockProperties()
            {
                icon = GetSprite(systemType, businessId),
                targetPos = GetTargetPos(systemType, businessId)
            };
            var panel = uiManager.ShowPanel(nameof(UIPanelUnlock), properties);

        }

        private void OnPanelComplete(UIPanelEventCloseBtnClicked e)
        {
            var panelData = e.Body as UIPanelUnlock.UIPanelUnlockPanelData;
            if (panelData == null) return;

            if (openArgs != null)
            {
                //解锁界面完成后，打开对应的入口界面
                switch (openArgs.SystemType)
                {
                    case SystemType.Deploy:
                        var arg = new List<UIMainEntrance>();
                        arg.Add(UIMainEntrance.EntranceDeploy);

                        var controllerArgs = new UIMainMenuController.ControllerArgs();
                        controllerArgs.panelName = nameof(UIPanelMainMenu);
                        controllerArgs.menuItems = arg;

                        eventManager.Raise<UIMainMenuController.Open>(controllerArgs);
                        uiManager.HidePanel(nameof(UIPanelUnlock));
                        break;
                    default:
                        throw new NotImplementedException("没有实现的系统类型 " + openArgs.SystemType);
                }
                openArgs = null;
            }
        }

        Sprite GetSprite(SystemType systemType, string businessId)
        {
            switch(systemType)
            {
                case SystemType.Deploy:
                    var deployConfig = configManager.GetEntranceIconPath("3");
                    if (deployConfig != null)
                    {
                        return spritesManager.GetSprite(deployConfig);
                    }
                    break;
                 default:
                    throw new NotImplementedException("没有实现的系统类型 " + systemType);
            }
            return null;
        }

        Vector2? GetTargetPos(SystemType systemType, string businessId)
        {
            switch(systemType)
            {
                case SystemType.Deploy:
                    return new Vector2(7, -4);                 
                default:
                    throw new NotImplementedException("没有实现的系统类型 " + systemType);
            }
        }
    }
}
