using Adic;
using Adic.Container;
using Game.Common;
using Game.Share;
using JFramework;
using JFramework.Game.View;
using System;
using System.Collections.Generic;
using Tiktok;
using UnityEngine;


namespace GameCommands
{
    public class CommandFight : Command
    {
        [Inject]
        IInjectionContainer container;

        [Inject]
        TiktokUnityHttpRequest httpRequest;

        [Inject]
        IObjectPool classPool;

        [Inject]
        EventManager eventManager;

        [Inject]
        ITransitionProvider transitionProvider;

        public override async void Execute(params object[] parameters)
        {
            this.Retain();

            var nodeUid = (string)parameters[0];
            var sceneType = (SceneType)parameters[1];

            var req = classPool.Rent<RequestFight>();
            req.LevelNodeBusinessId = nodeUid;

            //发送战斗请求事件，可以做一些消息拦截工作，比如货币的更新通知可以暂时缓存，等待战斗退出后再刷新UI
            eventManager.Raise<EventRequestCombat>(nodeUid);
            ResponseFight result = null;
            try
            {
                 result = await httpRequest.RequestFight(req);
            }
            catch(Exception e)
            {
                var controllerArgs = container.Resolve<UIWarningMessageController.ControllerArgs>();
                controllerArgs.Message = e.Message;
                controllerArgs.Type = UIWarningMessageController.WarningType.Error;
                controllerArgs.panelName = nameof(UIPanelWarningMessage);
                eventManager.Raise<UIWarningMessageController.Open>(controllerArgs);
                this.Release();
                classPool.Return(req);
                return;
            }
            

            Debug.Log("RequestFight response");
            //eventManager.Raise<EventStartCombat>(result);
            classPool.Return(req);

            var transition = await transitionProvider.InstantiateAsync(TransitionType.SMFadeTransition.ToString());
            // 并发开始
            await transition.TransitionOut();

            var context = container.Resolve<TiktokSceneSMContext>();

            var arg = new CombatSceneTransitionArg();
            arg.SceneType = sceneType;
            arg.FightResponse = result;
            arg.LevelNodeBusinessId = nodeUid;


            await context.sm.SwitchToCombat(arg);

            await transition.TransitionIn();


            this.Release();
        }

    }


}
