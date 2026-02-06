using EnhancedScrollerAdvance;
using TMPro;
using UnityEngine.UI;


namespace JFramework.Game.View
{
    public class UIShopItemScrollerUnitView : EnhancedUnitViewV2
    {
        public class Factory : EnhancedUnitViewPlaceHolderFactoryV2<UIShopItemScrollerUnitView> { }

        protected override void OnInitialize()
        {
            //txtName = GetBindingComponent("txtName") as TextMeshProUGUI;
            //txtProgress = GetBindingComponent("txtProgress") as TextMeshProUGUI;
            //imgFill = GetBindingComponent("imgFill") as Image;
            //btnClick = GetBindingComponent("btnClick") as Button;
            //btnClick.onClicked.AddListener(() =>
            //{
            //    //点击关卡单元，发送事件
            //    SendUnitCustomEvent(OnLevelUnitClicked, (_data.UnitData as UnitData).levelUid);
            //});
        }

        public override void OnRefreshCellView()
        {
            //var unitData = _data.UnitData as UnitData;

            //txtName.text = unitData.name;
            //txtProgress.text = unitData.progress;
            //imgFill.fillAmount = unitData.fillAmount;
        }
    }
}
