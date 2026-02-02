using Adic;
using Adic.Container;
using EnhancedScrollerAdvance;
using Game.Common;
using Game.Share;
using JFramework;
using JFramework.Game.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Tiktok
{
    /// <summary>
    /// 武将列表控制器，处理打开和关闭武将列表的事件，以及内部的滚动列表数据转换和视图工厂创建。
    /// </summary>
    public class UISamuraisListController : ViewController
    {
        public class ControllerArgs : ControllerBaseArgs
        {
            public List<SamuraiDTO> samuraiDTOs;
        }

        [Inject]
        protected TiktokGameObjectManager gameObjectManager;

        [Inject]
        protected TiktokConfigManager tiktokConfigManager;

        [Inject]
        protected TiktokSpritesManager spritesManager;

        [Inject]
        UIScrollerUnitViewDataConverter dataConverter;

        [Inject]
        TiktokGameDataManager tiktokGameDataManager;

        [Inject]
        ILanguageManager languageManager;

        [Inject]
        public UISamuraisListController(EventManager eventManager) : base(eventManager)
        {
        }
        public override void OnStart()
        {
            base.OnStart();
            //eventManager.AddListener<Open>(OnOpenSamuraiList);
            eventManager.AddListener<UIPanelEventCloseBtnClicked>(OnCloseSamuraiList);
        }


        public override void OnStop()
        {
            base.OnStop();
            //eventManager.RemoveListener<Open>(OnOpenSamuraiList);
            eventManager.RemoveListener<UIPanelEventCloseBtnClicked>(OnCloseSamuraiList);
        }

        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            //var samuraisModel = e.Body as SamuraisModel;
            var samuraiProperties = new UIPanelSamuraisListProperties();
            samuraiProperties.dataList = dataConverter.Convert(controllerArgs.samuraiDTOs);
            var buildingLevel = tiktokGameDataManager.GetBuildingLevel("1");
            var strCount = controllerArgs.samuraiDTOs.Count + "/" + tiktokConfigManager.GetBuildingArg("1", buildingLevel);
            samuraiProperties.count = string.Format(languageManager.GetText("120001"), strCount);
            samuraiProperties.title = languageManager.GetText("2001") + " " + string.Format(languageManager.GetText("120002"), buildingLevel);
            var screenId = uiManager.ShowPanel(nameof(UIPanelSamuraisList), samuraiProperties);
        }

        ///// <summary>
        ///// 打开武将列表
        ///// </summary>
        ///// <param name="e"></param>
        //private void OnOpenSamuraiList(Open e)
        //{
        //    var samuraisModel = e.Body as SamuraisModel;
        //    var samuraiProperties = new UIPanelSamuraisListProperties();
        //    samuraiProperties.dataList = dataConverter.Convert(samuraisModel.GetAll());
        //    var screenId = uiManager.ShowPanel(nameof(UIPanelSamuraisList), samuraiProperties);

        //}

        /// <summary>
        /// 关闭按钮被点击了
        /// </summary>
        /// <param name="e"></param>
        private void OnCloseSamuraiList(UIPanelEventCloseBtnClicked e)
        {
            var panelData = e.Body as UIPanelSamuraisList.UIPanelSamuraisListPanelData;
            if (panelData == null) return;

            var panel = panelData.panel;
            uiManager.HidePanel(panel.ScreenId);
        }


    }
}
