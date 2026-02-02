using deVoid.UIFramework;
using Game.Common;
using UnityEngine;

namespace JFramework.Game.View
{
    public class UIPanelHpPool : UIPanelBase<UIPanelHpPoolProperties>
    {
        //[SerializeField] BaseSingleTextView txtHpPool;
        [SerializeField] BaseSingleTextView txtTitle;
        public class UIPanelHpPoolPanelData : BasePanelData
        {

        }

        protected override void OnPanelRefresh(UIPanelHpPoolProperties properties)
        {
            //txtHpPool.Refresh(properties.hpPool);
            txtTitle.Refresh(properties.title);
        }
        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelHpPoolPanelData() { panel = this };
        }
    }

    public class UIPanelHpPoolProperties : PanelProperties
    {
        public string title;
    }
}
