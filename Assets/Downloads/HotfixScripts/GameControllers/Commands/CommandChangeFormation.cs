using Adic;
using Adic.Container;
using Game.Share;
using JFramework;
using JFramework.Game.View;
using System;
using Tiktok;
using UnityEngine;


namespace GameCommands
{
    public class CommandChangeFormation : Command
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

            var formationBusinessId = (string)parameters[0];

            var req = classPool.Rent<RequestChangeFormation>();
            req.FormationType = FormationType.FormationAtk;
            req.FormationBusinessId = formationBusinessId;

            ResponseChangeFormation result = null;
            try
            {
                result = await httpRequest.RequestChangeFormation(req);
            }
            catch (Exception e)
            {
                //Debug.LogError(e.Message);
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
