using deVoid.UIFramework;
using JFramework.Unity;
using System;
using UnityEngine;

namespace Game
{
    public class  UIPanelLogin : UIPanelBase<UIPanelLoginProperties>
    {
        public event Action onLoginButtonClicked;

        [SerializeField] AdvancedButton btnLogin;

        protected override void OnPanelHide()
        {
            base.OnPanelHide();

            if(btnLogin != null)
            {
                btnLogin.onClicked -= OnLoginButtonClicked;
            }
        }


        protected override void OnPanelShow()
        {
            base.OnPanelShow();
            if (btnLogin != null)
            {
                btnLogin.onClicked += OnLoginButtonClicked;
            }
        }

        private void OnLoginButtonClicked(object target)
        {
            onLoginButtonClicked?.Invoke();
        }
    }

    public class UIPanelLoginProperties : PanelProperties
    {
        //public string prefabName;
    }
}