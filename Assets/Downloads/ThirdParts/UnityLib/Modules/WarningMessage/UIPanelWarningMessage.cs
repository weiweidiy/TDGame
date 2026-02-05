using deVoid.UIFramework;
using Game.Common;
using System;
using UnityEngine;

namespace JFramework.Game.View
{
    public class UIPanelWarningMessage : UIPanelBase<UIPanelWarningMessageProperties>
    {
        //public class EventCloseBtnClicked : Event { }

        public class UIPanelWarningMessagePanelData : BasePanelData
        {
        }

        [SerializeField] TipsView tipsView;


        private void OnComplete()
        {
            SendEvent<UIPanelEventCloseBtnClicked>(CreatePanelData());
        }

        protected override void OnPanelRefresh(UIPanelWarningMessageProperties properties)
        {
            tipsView.gameObject.SetActive(true);
            tipsView.Show(properties.message);
        }

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelWarningMessagePanelData() { panel = this };
        }

        protected override void OnPanelEnable()
        {
            base.OnPanelEnable();
            tipsView.onComplete += OnComplete;
        }

        protected override void OnPanelHide()
        {
            base.OnPanelHide();
            tipsView.onComplete -= OnComplete;
        }
    }

    public class UIPanelWarningMessageProperties : PanelProperties
    {
        public string message { get; set; }

    }
}
