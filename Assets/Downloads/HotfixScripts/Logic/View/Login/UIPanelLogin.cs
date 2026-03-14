using deVoid.UIFramework;
using JFramework.Unity;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class  UIPanelLogin : UIPanelBase<UIPanelLoginProperties>
    {
        public event Action<string> onLoginButtonClicked;

        [SerializeField] AdvancedButton btnLogin;

        [SerializeField] TMP_InputField inputAccount;

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
            onLoginButtonClicked?.Invoke(inputAccount.text);
        }
    }

    public class UIPanelLoginProperties : PanelProperties
    {
        //public string prefabName;
    }
}