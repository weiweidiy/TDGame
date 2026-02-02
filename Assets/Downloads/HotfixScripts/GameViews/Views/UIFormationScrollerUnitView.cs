using EnhancedScrollerAdvance;
using Game.Common;
using Game.Share;
using Tiktok;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace JFramework.Game.View
{
    public class UIFormationScrollerUnitView : EnhancedUnitViewV2
    {
        public class Factory : EnhancedUnitViewPlaceHolderFactoryV2<UIFormationScrollerUnitView> { }

        public const string EventFormationClick = "EventFormationClick";


        Image formationIcon;
        TextMeshProUGUI txtName;
        AdvancedButton btnFormation;
        GameObject goSelect;


        public class UnitData
        {
            public FormationDTO dto;
            public Sprite formationIcon;
            public string businessId;
            public string name;
        }

        protected override void OnInitialize()
        {
            formationIcon = GetBindingComponent("formationIcon") as Image;
            txtName = GetBindingComponent("txtName") as TextMeshProUGUI;
            btnFormation = GetBindingComponent("btnFormation") as AdvancedButton;
            goSelect = GetBindingComponent("goSelect") as GameObject;

            btnFormation.onClick.AddListener(() =>
            {
                SendUnitCustomEvent(EventFormationClick, _data.UnitData);
            });

        }

        public override void OnRefreshCellView()
        {
            var unitData = _data.UnitData as UnitData;
            formationIcon.sprite = unitData.formationIcon;
            txtName.text = unitData.name;
            goSelect.SetActive(unitData.dto != null);
        }
    }
}
