using Adic;
using Game.Common;
using JFramework;
using JFramework.Game.View;
using System;
using System.Threading.Tasks;

namespace Tiktok
{
    public class TiktokNetworkHolding : IRunable
    {
        public RunableExtraData ExtraData { get; set ; }
        public bool IsRunning { get ; set ; }

        public event Action<IRunable> onComplete;

        UIManager uiManager;
        [Inject]
        public TiktokNetworkHolding(UIManager uiManager)
        {
            this.uiManager = uiManager;
        }

        public Task Start(RunableExtraData extraData, TaskCompletionSource<bool> tcs = null)
        {
            uiManager.ShowPanel<UIPanelNetworkHoldingProperties>(nameof(UIPanelNetworkHolding), null);
            onComplete?.Invoke(this);
            return Task.CompletedTask;
        }

        public void Stop()
        {
            uiManager.HidePanel(nameof(UIPanelNetworkHolding));
            onComplete?.Invoke(this);
        }

        public void Update(RunableExtraData extraData)
        {
            
        }
    }
}

