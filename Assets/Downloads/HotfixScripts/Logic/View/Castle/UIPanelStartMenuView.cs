using JFramework.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{


    public class UIPanelStartMenuView : View
    {
        public event Action onStartFightClicked;

        UIPanelStartMenu panel;
        public override void Open<TArg>(TArg args)
        {
            var uiManager = GetUIManager();
            panel = uiManager.ShowPanel(args.prefabName, new UIPanelStartMenuProperties()) as UIPanelStartMenu;
            panel.onFightButtonClicked += Panel_onFightButtonClicked;
        }

        public override void Close()
        {
            panel.onFightButtonClicked -= Panel_onFightButtonClicked;
        }
        public override void Refresh<TArg>(TArg args)
        {
            throw new System.NotImplementedException();
        }

        private void Panel_onFightButtonClicked()
        {
            onStartFightClicked?.Invoke();
        }
    }
}

