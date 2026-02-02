using Adic;
using Adic.Container;
using Game.Share;
using JFramework;
using JFramework.Game.View;
using System;
using System.Threading.Tasks;
using Tiktok;
using UnityEngine;


namespace GameCommands
{
    public class CommandDraw : Command
    {
        [Inject]
        IInjectionContainer container;
        [Inject]
        TiktokUnityHttpRequest httpRequest;
        [Inject]
        IObjectPool classPool;
        [Inject]
        LevelsModel levelsModel;
        [Inject]
        EventManager eventManager;
        public override async void Execute(params object[] parameters)
        {
            this.Retain();

            var poolType = (DrawSamuraiPoolType)parameters[0];
            var count = parameters.Length > 1 ? (int)parameters[1] : 1;

            var req = classPool.Rent<RequestDrawSamurai>();

            req.DrawPoolType = poolType;
            req.Count = count;

            ResponseDraw result = null;
            try
            {
                result = await httpRequest.RequestDraw(req);
            }catch(Exception e)
            {
                //Debug.LogError(e.Message);
                var uiArg = container.Resolve<UIWarningMessageController.ControllerArgs>();
                uiArg.Message = e.Message;
                uiArg.Type = UIWarningMessageController.WarningType.Error;
                uiArg.panelName = nameof(UIPanelWarningMessage);
                eventManager.Raise<UIWarningMessageController.Open>(uiArg);
            }

            eventManager.Raise<EventDrawSamurai>(result);
            classPool.Return(req);
            //更新模型数据，通过模型更新发送消息给UI
            this.Release();
        }
    }


}
