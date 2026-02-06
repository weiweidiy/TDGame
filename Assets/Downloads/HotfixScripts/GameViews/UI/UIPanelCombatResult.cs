using deVoid.UIFramework;
using Game.Common;
using System;
using TMPro;
using UnityEngine;

namespace JFramework.Game.View
{
    //public class UIPanelCombatResult : UIPanelBase<UIPanelCombatResultProperties>
    public class UIPanelCombatResult : UIPanelBase<UIPanelCombatResultProperties>
    {

        public class UIPanelCombatResultPanelData : BasePanelData
        {
            public int Result; // 0: Defeat, 1: Victory, 2: Draw
        }

        protected override void OnPanelRefresh(UIPanelCombatResultProperties properties)
        {
            
        }

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelCombatResultPanelData() { panel = this, Result = Properties.Result };
        }
    }

    public class UIPanelCombatResultProperties : PanelProperties
    {
        public int Result; // 0: Defeat, 1: Victory, 2: Draw

    }
}

//public class EventCloseBtnClicked : Event { }

//[SerializeField] AdvancedButton btnClose;

//protected override void OnPropertiesSet()
//{
//    base.OnPropertiesSet();
//    btnClose.onClicked.AddListener(OnBtnCloseClicked);
//}

//private void OnBtnCloseClicked()
//{
//    SendEvent<EventCloseBtnClicked>(this);
//}

//protected override void WhileHiding()
//{
//    base.WhileHiding();
//    btnClose.onClicked.RemoveListener(OnBtnCloseClicked);

//}