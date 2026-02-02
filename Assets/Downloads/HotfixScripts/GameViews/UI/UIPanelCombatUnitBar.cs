using deVoid.UIFramework;

using System;

using Tiktok;
using UnityEngine;

namespace JFramework.Game.View
{
    public class UIPanelCombatUnitBar : UIPanelBase<UIPanelCombatUnitBarProperties>
    {
        public class UIPanelCombatUnitBarPanelData : BasePanelData
        {
        }

        [SerializeField] CombatUnitDetailInfoView leftCombatUnitDetailInfoView;
        [SerializeField] CombatUnitDetailInfoView rightCombatUnitDetailInfoView;

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelCombatUnitBarPanelData() { panel = this };
        }

        protected override void OnPanelEnable()
        {
            base.OnPanelEnable();
            Properties.onRefreshDetailInfo += Properties_onRefreshDetailInfo;
        }

        protected override void OnPanelHide()
        {
            base.OnPanelHide();
            Properties.onRefreshDetailInfo -= Properties_onRefreshDetailInfo;
        }

        protected override void OnPanelRefresh(UIPanelCombatUnitBarProperties properties)
        {
            leftCombatUnitDetailInfoView.Refresh(Properties.leftUnitInfo);
            rightCombatUnitDetailInfoView.Refresh(Properties.rightUnitInfo);
        }


        private void Properties_onRefreshDetailInfo()
        {
            OnPanelRefresh(Properties);
        }
    }

    public class UIPanelCombatUnitBarProperties : PanelProperties
    {

        public event Action onRefreshDetailInfo;

        public CombatUnitDetailInfo leftUnitInfo;
        public CombatUnitDetailInfo rightUnitInfo;

        public void RefreshDetailInfo()
        {
            onRefreshDetailInfo?.Invoke();
        }
    }
}
