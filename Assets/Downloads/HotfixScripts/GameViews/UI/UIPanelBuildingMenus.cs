using Game.Common;
using System;
using Tiktok;
using UnityEngine;
using UnityEngine.EventSystems;
using static JFramework.Game.View.UIPanelBuildingMenus;

namespace JFramework.Game.View
{
    [Serializable]
    public class BuildingMenuItem : MenuItem<UIBuildingMenu>
    {
    }

    public class UIPanelBuildingMenus : UIPanelBasePopupMenus<UIBuildingMenu, BuildingMenuItem> 
    {
        [SerializeField] UIClickHandler uiClickHandler;
        public enum UIBuildingMenu
        {
            None = 0,
            Enter = 1, //武将列表
            Detail = 2, //建筑详情
            Upgrade = 3, //升级建筑
            Complete = 4,//建造完成
        }

        public class UIPanelBuildingMenusPanelData : UIPanelBaseMenusPanelData
        {

        }

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelBuildingMenusPanelData() { panel = this };
        }



        protected override void OnPanelEnable()
        {
            base.OnPanelEnable();

            uiClickHandler.onClicked += UiClickHandler_onClicked;
        }

        private void UiClickHandler_onClicked(object obj)
        {
            SendEvent<UIPanelEventCloseBtnClicked>(CreatePanelData());
        }

        protected override void OnPanelHide()
        {
            base.OnPanelHide();

            uiClickHandler.onClicked -= UiClickHandler_onClicked;
        }
    }

    public class UIPanelBuildingMenusProperties : UIPanelBasePopupMenusProperties<UIBuildingMenu>
    {

    }
}
