using Adic;
using Adic.Container;
using Game.Common;
using Game.Modules;
using Game.Share;
using JFramework;
using JFramework.Game.View;
using System;
using Tiktok;
using UnityEngine;


namespace GameCommands
{
    public class CommandDeploy : Command
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

            var point = (int)parameters[0];
            var samuraiId = (int)parameters[1];

            var req = classPool.Rent<RequestDeploy>();
            req.FormationType = FormationType.FormationAtk;
            req.FormationPoint = point;
            req.SamuraiId = samuraiId;

            ResponseDeploy result = null;
            try
            {
                result = await httpRequest.RequestDeploy(req);
            }
            catch (Exception e)
            {
                var uiArg = container.Resolve<UIWarningMessageController.ControllerArgs>();
                uiArg.Message = e.Message;
                uiArg.Type = UIWarningMessageController.WarningType.Error;
                uiArg.panelName = nameof(UIPanelWarningMessage);
                eventManager.Raise<UIWarningMessageController.Open>(uiArg);
            }

            //eventManager.Raise<EventDrawSamurai>(result);
            classPool.Return(req);
            //更新模型数据，通过模型更新发送消息给UI
            this.Release();
        }
    }


}
