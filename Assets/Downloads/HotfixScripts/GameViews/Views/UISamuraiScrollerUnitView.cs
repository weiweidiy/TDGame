using EnhancedScrollerAdvance;
using Game.Share;
using System;
using System.Collections.Generic;
using Tiktok;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace JFramework.Game.View
{
    public class UISamuraiScrollerUnitView : EnhancedUnitViewV2
    {
        public class Factory : EnhancedUnitViewPlaceHolderFactoryV2<UISamuraiScrollerUnitView> { }

        public class CustomInitData : InitData
        {
            public Image headIcon;
        }

        public class CustomRefreshData : RefreshData
        {
            public int samuraiId;
            public Image headIcon;
        }

        public class UnitData
        {
            public SamuraiDTO dto;
            public Sprite headIcon;
            public Sprite rareIcon;
            public string name;
            public SamuraiDetailInfo samuraiInfo;
        }

        Image headIcon;
        Button btnSelection;
        Image imgRare;
        GameObject goSelection;
        SamuraiDetailInfoView samuraiInfo;

        protected override void OnInitialize()
        {
            headIcon = GetBindingComponent("headIcon") as Image;
            btnSelection = GetBindingComponent("btnSelection") as Button;
            imgRare = GetBindingComponent("imgRare") as Image;
            samuraiInfo = GetBindingComponent("samuraiInfo") as SamuraiDetailInfoView;
            goSelection = GetBindingComponent("goSelection") as GameObject;

            if (btnSelection != null)
                btnSelection.onClick.AddListener(() => SelectionClicked(this));
        }

        public override void OnRefreshCellView()
        {
            var unitData = _data.UnitData as UnitData;
            headIcon.sprite = unitData.headIcon;
            //txtName.text = unitData.name;
            imgRare.sprite = unitData.rareIcon;
            if (samuraiInfo != null)
                samuraiInfo.Refresh(unitData.samuraiInfo);

        }

        protected override InitData GetInitData()
        {
            var customData = new CustomInitData();
            customData.headIcon = headIcon;
            customData.cellGo = _go;
            return customData;
        }

        protected override RefreshData GetRefreshData()
        {
            var customData = new CustomRefreshData();
            var unitData = _data.UnitData as UnitData;
            customData.samuraiId = unitData.dto != null ? unitData.dto.Id : 0;
            customData.headIcon = headIcon;
            return customData;
        }

        public override void RefreshSelectedStatus(bool selected)
        {
            base.RefreshSelectedStatus(selected);

            if (goSelection != null)
                goSelection.SetActive(selected);
        }
    }
}
