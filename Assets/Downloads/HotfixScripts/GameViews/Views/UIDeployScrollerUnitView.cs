using EnhancedScrollerAdvance;
using System;
using System.ComponentModel.DataAnnotations;
using UnityEngine;
using UnityEngine.UI;


namespace JFramework.Game.View
{
    public class UIDeployScrollerUnitView : EnhancedUnitViewV2
    {
        public class Factory : EnhancedUnitViewPlaceHolderFactoryV2<UIDeployScrollerUnitView> { }

        public class  CustomInitData : InitData
        {
            public Image imgHead;
        }

        public class CustomRefreshData : RefreshData
        {
            public Image imgHead;
        }

        public class UnitData
        {
            public string businessId;
            public bool valid;
            public Sprite spHead;
        }

        GameObject goLock;
        Image imgHead;

        protected override void OnInitialize()
        {
            imgHead = GetBindingComponent("imgHead") as Image;
            goLock = GetBindingComponent("goLock") as GameObject;
        }

        public override void OnRefreshCellView()
        {
            var unitData = _data.UnitData as UnitData;
            goLock.SetActive(!unitData.valid);
            imgHead.gameObject.SetActive(unitData.spHead != null);
            if(unitData.spHead != null)
            {
                imgHead.sprite = unitData.spHead;
            }
        }

        protected override InitData GetInitData()
        {
            var initData = new CustomInitData();
            initData.cellGo = _go;
            initData.imgHead = imgHead;
            return initData;
        }

        protected override RefreshData GetRefreshData()
        {
            var refreshData = new CustomRefreshData();
            refreshData.unitData = _data.UnitData;
            refreshData.imgHead = imgHead;
            return refreshData;
        }
    }
}
