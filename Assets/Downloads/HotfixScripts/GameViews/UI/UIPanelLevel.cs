using deVoid.UIFramework;
using Game.Common;
using System;
using UnityEngine;

namespace JFramework.Game.View
{
    public class UIPanelLevel : UIPanelBase<UIPanelLevelProperties>
    {
        [SerializeField] AdvancedButton btnPre;
        [SerializeField] AdvancedButton btnNext;

        public class UIPanelLevelPanelData : BasePanelData
        {

        }

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelLevelPanelData() { panel = this };
        }

        protected override void OnPanelEnable()
        {
            base.OnPanelEnable();

            btnPre.advancedEvents.onClick.AddListener(() =>
            {
                Properties.OnBtnPreClick(this);
            });

            btnNext.advancedEvents.onClick.AddListener(() =>
            {
                Properties.OnBtnNextClick(this);
            });

            Properties.onRefresh += Properties_onRefresh;
        }

        protected override void OnPanelHide()
        {
            base.OnPanelHide();

            btnPre.advancedEvents.onClick.RemoveAllListeners();
            btnNext.advancedEvents.onClick.RemoveAllListeners();

            Properties.onRefresh -= Properties_onRefresh;
        }

        protected override void OnPanelRefresh(UIPanelLevelProperties properties)
        {
            btnPre.gameObject.SetActive(Properties.preLevelValid);
            btnNext.gameObject.SetActive(Properties.nextLevelValid);
        }


        private void Properties_onRefresh()
        {
            OnPanelRefresh(Properties);
        }


    }

    public class UIPanelLevelProperties : PanelProperties
    {
        public event Action onRefresh;

        public event Action<UIPanelLevel> onPreClick;
        public event Action<UIPanelLevel> onNextClick;

        public bool preLevelValid { get; set; }
        public bool nextLevelValid { get; set; }

        public void OnBtnPreClick(UIPanelLevel controller)
        {
            onPreClick?.Invoke(controller);
        }
        public void OnBtnNextClick(UIPanelLevel controller)
        {
            onNextClick?.Invoke(controller);
        }

        public void Refresh()
        {
            onRefresh?.Invoke();
        }
    }
}
