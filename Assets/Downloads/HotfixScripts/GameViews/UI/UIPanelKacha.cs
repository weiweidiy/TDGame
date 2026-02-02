using deVoid.UIFramework;
using EnhancedScrollerAdvance;
using Game.Common;
using System.Collections.Generic;
using UnityEngine;



namespace JFramework.Game.View
{
    public class UIPanelKacha : UIPanelBase<UIPanelKachaProperties>
    {

        public class UIPanelKachaPanelData : BasePanelData
        {
 
        }
        protected override void OnPanelRefresh(UIPanelKachaProperties properties)
        {
            //throw new System.NotImplementedException();
        }

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelKachaPanelData() { panel = this };
        }
    }

    public class UIPanelKachaProperties : PanelProperties
    {
        public List<EnhancedDataV2> dataKachaPoolsList;
    }
}
