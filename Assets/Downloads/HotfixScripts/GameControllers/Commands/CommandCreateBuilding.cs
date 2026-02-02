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
    public class CommandCreateBuilding : Command
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
            var buildingBusinessId = (string)parameters[0];
            var req = classPool.Rent<RequestCreateBuilding>();
            req.BuildingBusinessId = buildingBusinessId;
            ResponseCreateBuilding result = null;
            try
            {
                result = await httpRequest.RequestCreateBuilding(req);
            }
            catch (Exception e)
            {
                var uiArg = container.Resolve<UIWarningMessageController.ControllerArgs>();
                uiArg.Message = e.Message;
                uiArg.Type = UIWarningMessageController.WarningType.Error;
                uiArg.panelName = nameof(UIPanelWarningMessage);
                eventManager.Raise<UIWarningMessageController.Open>(uiArg);
                Debug.LogError(e.Message);
            }
            classPool.Return(req);
            this.Release();
        }
    }


}
