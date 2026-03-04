using deVoid.UIFramework;
using JFramework.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UIPanelStartMenu : UIPanelBase<UIPanelStartMenuProperties>
    {
        public event Action onFightButtonClicked;

        [SerializeField] AdvancedButton btnStartFight;


        protected override void OnPanelShow()
        {
            base.OnPanelShow();
            if (btnStartFight != null)
            {
                btnStartFight.onClicked += OnFightButtonClicked;
            }
        }

        protected override void OnPanelHide()
        {
            base.OnPanelHide();

            if (btnStartFight != null)
            {
                btnStartFight.onClicked -= OnFightButtonClicked;
            }
        }

        private void OnFightButtonClicked(object target)
        {
            onFightButtonClicked?.Invoke();
        }
    }

    public class UIPanelStartMenuProperties : PanelProperties
    {
        //public string prefabName;
    }
}

