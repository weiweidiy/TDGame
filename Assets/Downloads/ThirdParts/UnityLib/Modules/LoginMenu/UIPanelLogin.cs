using deVoid.UIFramework;
using Game.Common;
using JFramework.Game.View;
using System;
using UnityEngine;
using static Game.Modules.UIPanelLogin;


namespace Game.Modules
{
    //public class 
    public class UIPanelLogin : UIPanelBase<UIPanelLoginProperties>
    {
        //public class EventBtnEnterClick : Event { }

        public class UIPanelLoginPanelData : BasePanelData
        {

        }

        [SerializeField] AdvancedButton btnEnter;
        //[SerializeField] TextMeshProUGUI txtConfirm;

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
                //SendEvent<EventBtnEnterClick>(CreatePanelData());
                Properties.OnClick(CreatePanelData() as UIPanelLoginPanelData);
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
        public event Action<UIPanelLoginPanelData> onClick;

        public void OnClick(UIPanelLoginPanelData panelData)
        {
            onClick?.Invoke(panelData);
        }
    }


}
