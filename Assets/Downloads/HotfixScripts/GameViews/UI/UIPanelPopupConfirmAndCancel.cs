using deVoid.UIFramework;
using Game.Common;
using UnityEngine;

namespace JFramework.Game.View
{
    public class UIPanelPopupConfirmAndCancel : UIPanelBase<UIPanelPopupConfirmAndCancelProperties>
    {
        [SerializeField] BaseSingleTextView txtTitle;
        [SerializeField] BaseSingleTextView txtContent;
        [SerializeField] BaseSingleTextView txtBtnConfirm;
        [SerializeField] BaseSingleTextView txtBtnCancel;
        public class UIPanelPopupConfirmAndCancelPanelData : BasePanelData
        {
        }
        protected override void OnPanelRefresh(UIPanelPopupConfirmAndCancelProperties properties)
        {
            txtTitle.Refresh(properties.title);

        }
        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelPopupConfirmAndCancelPanelData() { panel = this };
        }


    }


    public class UIPanelPopupConfirmAndCancelProperties : PanelProperties
    {
        public string title;
    }
}
