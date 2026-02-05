using deVoid.UIFramework;

namespace JFramework.Game.View
{
    public class UIPanelNetworkHolding : UIPanelBase<UIPanelNetworkHoldingProperties> 
    {
        public class UIPanelNetworkHoldingData : BasePanelData
        {

        }
        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelNetworkHoldingData() { panel = this };
        }

        protected override void OnPanelRefresh(UIPanelNetworkHoldingProperties properties)
        {
            
        }


    }

    public class UIPanelNetworkHoldingProperties : PanelProperties
    {

    }
}
