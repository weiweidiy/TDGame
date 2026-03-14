using JFramework.Unity;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    public class UIPanelLoginView : View
    {
        public event Action<string> onLoginClicked;

        UIPanelLogin panel;

        public override void Open<TArg>(TArg args)
        {
            Debug.Log("DemoLoginController Open " + args.prefabName);
            panel = GetUIManager().ShowPanel(args.prefabName, new UIPanelLoginProperties()) as UIPanelLogin;
            panel.onLoginButtonClicked += OnLoginButtonClicked;
        }

        public override void Close()
        {
            panel.onLoginButtonClicked -= OnLoginButtonClicked;
        }

        public override void Refresh<TArg>(TArg args)
        {
            throw new NotImplementedException();
        }

        private void OnLoginButtonClicked(string account)
        {
            onLoginClicked?.Invoke(account);
        }
    }

}