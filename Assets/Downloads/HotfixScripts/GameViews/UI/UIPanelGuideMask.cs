using deVoid.UIFramework;
using Game.Common;
using System;
using UnityEngine;
using UnityEngine.UI;
using static JFramework.Game.View.UIPanelGuideMask;

namespace JFramework.Game.View
{

    public class UIPanelGuideMask : UIPanelBase<UIPanelGuideProperties>
    {
        public enum MaskType
        {
            Rect,
            Cycle,
            Parallelogram,
        }

        public class  UIPanelGuideMaskPanelData : BasePanelData
        {
            
        }

        [SerializeField] GuideMaskDrawer guideMaskController;

        protected override void OnPanelEnable()
        {
            base.OnPanelEnable();

            Properties.onClose += OnCloseBtnClicked;
        }

        protected override void OnPanelHide()
        {
            base.OnPanelHide();

            Properties.onClose -= OnCloseBtnClicked;
        }


        private void OnCloseBtnClicked()
        {
            SendEvent<UIPanelEventCloseBtnClicked>(CreatePanelData());
        }

        protected override void OnPanelRefresh(UIPanelGuideProperties properties)
        {
            switch (properties.maskType)
            {
                case MaskType.Rect:
                    guideMaskController.ShowRect(properties.TargetRT);
                    break;
                case MaskType.Cycle:
                    guideMaskController.ShowCycle(properties.TargetRT);
                    break;
                case MaskType.Parallelogram:
                    guideMaskController.ShowParallelogram(properties.TargetRT, 0.5f);
                    break;
            }
        }

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelGuideMaskPanelData() { panel = this };
        }


    }

    public class UIPanelGuideProperties : PanelProperties
    {
        public event Action onClose;

        /// <summary>
        /// canvas坐标系下的目标区域
        /// </summary>
        public Rect TargetRT;
        public MaskType maskType = MaskType.Rect;

        public void Close()
        {
            onClose?.Invoke();
        }
    }
}
