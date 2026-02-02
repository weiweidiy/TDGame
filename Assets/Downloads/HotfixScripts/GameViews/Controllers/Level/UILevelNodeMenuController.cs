using Adic;
using Game.Common;
using Game.Share;
using JFramework;
using JFramework.Game.View;
using System;
using System.Collections.Generic;
using UnityEngine;
using static JFramework.Game.View.UIPanelLevelNodeMenus;
using Event = JFramework.Event;


namespace Tiktok
{
    public class UILevelNodeMenuController : ViewController
    {

        /// <summary>
        /// 攻击按钮被点击了
        /// </summary>
        public class UIControllerEventAttackClicked : Event { }

        /// <summary>
        /// panel显示完成
        /// </summary>
        public class UIControllerEventPanelShowed : Event { }

        /// <summary>
        /// 控制器数据
        /// </summary>
        public class ControllerArgs : ControllerBaseArgs
        {
            public UIPanelLevelNodeMenus panel;
            public Vector2 worldPosition;
            public LevelNodeDTO dto;
        }

        //[Inject]
        //UIManager uiManager;

        public UILevelNodeMenuController(EventManager eventManager) : base(eventManager)
        {
        }

        public override void OnStart()
        {
            base.OnStart();
            //eventManager.AddListener<Open>(OnOpen);

            eventManager.AddListener<UIPanelLevelNodeMenus.UIPanelEventMenuClicked>(OnBtnClicked);
            eventManager.AddListener<UIPanelEventShowed>(OnPanelShowed);
        }


        public override void OnStop()
        {
            base.OnStop();
            //eventManager.RemoveListener<Open>(OnOpen);

            eventManager.RemoveListener<UIPanelLevelNodeMenus.UIPanelEventMenuClicked>(OnBtnClicked);
            eventManager.RemoveListener<UIPanelEventShowed>(OnPanelShowed);

        }

        /// <summary>
        /// 打开panel
        /// </summary>
        /// <param name="e"></param>
        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            var properties = new UIPanelLevelNodeMenusProperties()
            {
                menuItems = new List<UILevelNodeMenu>() { UILevelNodeMenu.Attack, UILevelNodeMenu.Detail},
                dto = controllerArgs.dto,
                worldPosition = controllerArgs.worldPosition,
            };
            var controller = uiManager.ShowPanel(controllerArgs.panelName, properties) as UIPanelLevelNodeMenus;          
        }

        /// <summary>
        /// panel显示完成
        /// </summary>
        /// <param name="e"></param>
        private void OnPanelShowed(UIPanelEventShowed e)
        {
            var panelData = e.Body as UIPanelLevelNodeMenus.UIPanelLevelNodePanelData;
            if (panelData == null)
                return;

            SendEvent<UIControllerEventPanelShowed>(new ControllerArgs() { panel = panelData.panel as UIPanelLevelNodeMenus, dto = panelData.dto });
        }

        #region panel交互事件
        /// <summary>
        /// 按钮被点击了
        /// </summary>
        /// <param name="e"></param>
        private void OnBtnClicked(UIPanelLevelNodeMenus.UIPanelEventMenuClicked e)
        {
            var panelData = e.Body as UIPanelLevelNodeMenus.UIPanelLevelNodePanelData;
            if (panelData == null)
                return;

            uiManager.HidePanel(panelData.panel.ScreenId);
            switch (panelData.menuItem.Key)
            {
                case UILevelNodeMenu.Attack:
                    SendEvent<UIControllerEventAttackClicked>(panelData.dto.BusinessId);
                    break;
                case UILevelNodeMenu.Detail:
                    var controllerArgs = new UILevelNodeDetailController.ControllerArgs()
                    {
                        panelName = nameof(UIPanelLevelNodeDetail),
                        dto = panelData.dto
                    };

                    SendEvent<UILevelNodeDetailController.Open>(controllerArgs);
                    break;
                default:
                    throw new Exception("未处理的UILevelNodeMenu按钮点击事件:" + panelData.menuItem.Key);
            }
        }
        #endregion
    }
}
