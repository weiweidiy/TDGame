using Adic;
using Adic.Container;
using Game.Share;
using JFramework;
using JFramework.Game.View;
using System;
using System.Threading.Tasks;
using Tiktok;


namespace GameCommands
{
    public class CommandCompleteGuide : Command
    {
        [Inject]
        IInjectionContainer container;
        [Inject]
        TiktokUnityHttpRequest httpRequest;
        [Inject]
        IObjectPool classPool;
        [Inject]
        EventManager eventManager;
        public override async void Execute(params object[] parameters)
        {
            this.Retain();
            var guideBusinessId = (string)parameters[0];
            var req = classPool.Rent<RequestCompleteGuideStep>();
            req.GuideBusinessId = guideBusinessId;
            ResponseCompleteGuideStep result = null;
            try
            {
                result = await httpRequest.RequestCompleteGuideStep(req);
            }
            catch (Exception e)
            {
                var uiArg = container.Resolve<UIWarningMessageController.ControllerArgs>();
                uiArg.Message = e.Message;
                uiArg.Type = UIWarningMessageController.WarningType.Error;
                uiArg.panelName = nameof(UIPanelWarningMessage);
                eventManager.Raise<UIWarningMessageController.Open>(uiArg);
            }

            classPool.Return(req);
            this.Release();
        }
    }


}
