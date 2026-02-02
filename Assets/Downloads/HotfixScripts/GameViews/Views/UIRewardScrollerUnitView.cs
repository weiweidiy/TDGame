using EnhancedScrollerAdvance;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JFramework.Game.View
{
    public class UIRewardScrollerUnitView : EnhancedUnitViewV2
    {
        public class Factory : EnhancedUnitViewPlaceHolderFactoryV2<UIRewardScrollerUnitView> { }

        public class UnitData
        {
            public Sprite spIcon;
            public Sprite spFramework;
            public int count;
        }

        Image rewardIcon;
        Image rewardFramework;
        TextMeshProUGUI txtCount;

        protected override void OnInitialize()
        {
            rewardIcon = GetBindingComponent("rewardIcon") as Image;
            rewardFramework = GetBindingComponent("rewardFramework") as Image;
            txtCount = GetBindingComponent("txtCount") as TextMeshProUGUI;
        }

        public override void OnRefreshCellView()
        {
            var data = _data.UnitData as UnitData;
            txtCount.text = data.count > 1 ? data.count.ToString() : "";
            rewardIcon.sprite = data.spIcon;
        }

    }
}
