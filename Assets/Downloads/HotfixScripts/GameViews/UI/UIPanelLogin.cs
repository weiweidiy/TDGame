using Adic;
using Adic.Container;
using deVoid.UIFramework;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JFramework.Game.View
{
    //public class 
    public class UIPanelLogin : UIPanelBase<UIPanelLoginProperties>
    {
        public class EventBtnEnterClick : Event { }

        public class UIPanelLoginPanelData : BasePanelData
        {

        }

        [SerializeField] Button btnEnter;
        [SerializeField] TextMeshProUGUI txtConfirm;

        protected override void OnPanelRefresh(UIPanelLoginProperties properties)
        {
            
        }

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelLoginPanelData() { panel = this };
        }

        protected override void OnPanelEnable()
        {
            base.OnPanelEnable();
            btnEnter.onClick.AddListener(() =>
            {
                SendEvent<EventBtnEnterClick>(CreatePanelData());
            });
        }

        protected override void OnPanelHide()
        {
            base.OnPanelHide();
            btnEnter.onClick.RemoveAllListeners();
        }
    }


    public class UIPanelLoginProperties : PanelProperties
    {
        
    }


}
