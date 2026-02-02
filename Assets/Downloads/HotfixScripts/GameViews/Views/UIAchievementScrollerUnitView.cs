using EnhancedScrollerAdvance;
using System.Collections.Generic;
using Tiktok;
using TMPro;
using UnityEngine;


namespace JFramework.Game.View
{
    public class UIAchievementScrollerUnitView : EnhancedUnitViewV2
    {
        public class Factory : EnhancedUnitViewPlaceHolderFactoryV2<UIAchievementScrollerUnitView> { }

        public class UnitData
        {
            public string desc;
            public List<ResourceDetailInfo> resourceDetailInfos;
            public bool isAchieved;
        }

        TextMeshProUGUI descText;
        ResourceDetailInfoViewGroup rewards;
        GameObject goAchieved;


        protected override void OnInitialize()
        {
            descText = GetBindingComponent("descText") as TextMeshProUGUI;
            rewards = GetBindingComponent("rewards") as ResourceDetailInfoViewGroup;
            goAchieved = GetBindingComponent("goAchieved") as GameObject;
        }

        public override void OnRefreshCellView()
        {
            var unitData = _data.UnitData as UnitData;
            descText.text = unitData.desc;
            rewards.Refresh(unitData.resourceDetailInfos);
            goAchieved.SetActive(unitData.isAchieved);
        }

    }
}
