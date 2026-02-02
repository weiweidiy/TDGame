using EnhancedScrollerAdvance;
using System;
using System.Xml.Linq;
using TMPro;
using UnityEngine.UI;


namespace JFramework.Game.View
{
    public class UILevelListScrollerUnitView : EnhancedUnitViewV2
    {
        public class Factory : EnhancedUnitViewPlaceHolderFactoryV2<UILevelListScrollerUnitView> { }

        public class UnitData
        {
            public string levelUid;
            public string name;
            public string progress;
            public float fillAmount;
        }

        public const string OnLevelUnitClicked = "OnLevelUnitClicked";

        TextMeshProUGUI txtName;
        TextMeshProUGUI txtProgress;
        Image imgFill;
        Button btnClick;

        protected override void OnInitialize()
        {
            txtName = GetBindingComponent("txtName") as TextMeshProUGUI;
            txtProgress = GetBindingComponent("txtProgress") as TextMeshProUGUI;
            imgFill = GetBindingComponent("imgFill") as Image;
            btnClick = GetBindingComponent("btnClick") as Button;
            btnClick.onClick.AddListener(() =>
            {
                //点击关卡单元，发送事件
                SendUnitCustomEvent(OnLevelUnitClicked, (_data.UnitData as UnitData).levelUid);
            });
        }

        public override void OnRefreshCellView()
        {
            var unitData = _data.UnitData as UnitData;

            txtName.text = unitData.name;
            txtProgress.text = unitData.progress;
            imgFill.fillAmount = unitData.fillAmount;
        }


    }
}
