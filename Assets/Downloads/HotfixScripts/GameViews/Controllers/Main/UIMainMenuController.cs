using Adic;
using deVoid.UIFramework;
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
    public class UIMainMenuController : ViewController
    {
       // public class Open : Event { }

        public class EventUpdateEntrances : Event { }

        public class EventPanelShowed : Event { }

        public class EventEnteranceClicked : Event { }


        public class ControllerArgs : ControllerBaseArgs
        {
            public List<UIMainEntrance> menuItems; //入口按钮
        }
        //[Inject]
        //UIManager uiManager;

        [Inject]
        SamuraisModel samuraisModel;

        [Inject]
        FormationModel formationModel;

        [Inject]
        LevelsModel levelsModel;

        UIPanelMainMenuProperties properties;

        IPanelController panel;

        [Inject]
        protected FormationDeployModel formationDeployModel;

        public UIMainMenuController(EventManager eventManager) : base(eventManager)
        {
        }

        public override void OnStart()
        {
            base.OnStart();
            eventManager.AddListener<EventUpdateEntrances>(OnUpdateEntrance);
            eventManager.AddListener<UIPanelMainMenu.UIPanelEventMenuClicked>(OnEntranceClicked);
            eventManager.AddListener<UIPanelEventShowed>(OnPanelShowed);
        }


        public override void OnStop()
        {
            base.OnStop();
            eventManager.RemoveListener<EventUpdateEntrances>(OnUpdateEntrance);
            eventManager.RemoveListener<UIPanelMainMenu.UIPanelEventMenuClicked>(OnEntranceClicked);
            eventManager.RemoveListener<UIPanelEventShowed>(OnPanelShowed);
            properties = null;
        }

        private void OnPanelShowed(UIPanelEventShowed e)
        {
            var panelData = e.Body as UIPanelMainMenu.UIPanelMainMenuPanelData;
            if (panelData == null) return;

            SendEvent<EventPanelShowed>(panelData.activeMenus); //发出去的是一个List<GameObject>
        }

        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            var menuItems = controllerArgs.menuItems;
            if (menuItems != null)
            {
                properties = new UIPanelMainMenuProperties();
                properties.menuItems = menuItems;
                //显示底部按钮栏
                panel = uiManager.ShowPanel(controllerArgs.panelName, properties);
            }
        }

        /// <summary>
        /// 打开入口
        /// </summary>
        /// <param name="e"></param>
        private void OnUpdateEntrance(EventUpdateEntrances e)
        {
            var arg = e.Body as List<UIMainEntrance>;
            if (arg != null && properties != null)
            {
                properties.menuItems.AddRange(arg);
                properties.RefreshEnterance();
            }
        }

        public UIPanelMainMenu GetPanel()
        {
            return panel as UIPanelMainMenu;
        }

        private void OnEntranceClicked(UIPanelMainMenu.UIPanelEventMenuClicked e)
        {
            var panelData = e.Body as UIPanelMainMenu.UIPanelMainMenuPanelData;
            if (panelData == null) return;

            SendEvent<EventEnteranceClicked>(panelData.menuItem.Key);

            //var entrance = panelData.menuItem.key;
            //switch (entrance)
            //{
            //    case UIMainEntrance.EntranceSamuraisList: //to do: 移去gamestate里
            //        {
            //            var controllerArgs = new UISamuraisListController.ControllerArgs();
            //            controllerArgs.panelName = nameof(UIPanelSamuraisList);
            //            controllerArgs.samuraiDTOs = samuraisModel.GetAll();
            //            SendEvent<UISamuraisListController.Open>(controllerArgs);
            //        }

            //        break;
            //    case UIMainEntrance.EntranceDrawSamurai:
            //        {
            //            var controllerArgs = new UIKachaController.ControllerArgs();
            //            controllerArgs.panelName = nameof(UIPanelKacha);
            //            //打开关卡界面
            //            SendEvent<UIKachaController.Open>(controllerArgs);
            //        }
    
            //        break;
            //    case UIMainEntrance.EntranceDeploy:
            //        {
            //            var controllerArgs = new UIDeployController.ControllerArgs();
            //            controllerArgs.panelName = nameof(UIPanelDeploy);
            //            controllerArgs.formationDeployDTOs = formationDeployModel.GetAll();
            //            controllerArgs.samuraiDTOs = samuraisModel.GetAll();
            //            controllerArgs.formationDTOs = formationModel.GetAll();
            //            SendEvent<UIDeployController.Open>(controllerArgs);
            //        }   
            //        break;
            //    case UIMainEntrance.EntranceLevel:
            //        {
            //            Debug.Log("点击了关卡列表按钮EntranceLevel");
            //            var controllerArgs = new UILevelListController.ControllerArgs();
            //            controllerArgs.panelName = nameof(UIPanelLevelList);
            //            controllerArgs.levelNodeDTOs = levelsModel.GetAll();
            //            //打开关卡界面
            //            SendEvent<UILevelListController.Open>(controllerArgs);
            //        }
            //        break;
            //    default:
            //        throw new ArgumentOutOfRangeException("没有实现btnclick " + entrance);
            //}

        }


    }
}
