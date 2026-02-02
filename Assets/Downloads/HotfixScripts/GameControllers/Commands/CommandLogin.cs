using Adic;
using Adic.Container;
using Cysharp.Threading.Tasks;
using Game.Share;
using JFramework;
using JFramework.Game.View;
using System;
using Tiktok;
using UnityEngine;


namespace GameCommands
{
    public class CommandLogin : Command
    {
        [Inject]
        IInjectionContainer container;
        [Inject]
        TiktokUnityHttpRequest httpRequest;
        [Inject]
        IJNetwork network;
        [Inject]
        ITransitionProvider transitionProvider;
        [Inject]
        EventManager eventManager;
        [Inject]
        LevelsModel levelModel;
        [Inject]
        PlayerModel playerModel;
        [Inject]
        SamuraisModel samuraisModel;
        [Inject]
        CurrenciesModel currenciesModel;
        [Inject]
        FormationDeployModel formationDeployModel;
        [Inject]
        FormationModel formationModel;
        [Inject]
        BuildingModel buildingModel;
        [Inject]
        CurrentGuideStepModel guideModel;
        [Inject]
        HpPoolModel hpPoolModel;

        [Inject]
        TiktokGameDataManager gameDataManager;

        [Inject("Account")]
        string debugAccount;
        [Inject("ServerUrl")]
        string url;

        public override async void Execute(params object[] parameters)
        {

            var context = (TiktokSceneSMContext)parameters[0];

            this.Retain();


            var account = string.IsNullOrEmpty(debugAccount) ? "jcw29" : debugAccount;

            AccountDTO loginTask = null;

            try
            {
                loginTask = await httpRequest.RequestLogin(account, container.Resolve<TiktokNetworkHolding>());
            }
            catch(Exception e)
            {
                var uiArg = container.Resolve<UIWarningMessageController.ControllerArgs>();
                uiArg.Message = e.Message;
                uiArg.Type = UIWarningMessageController.WarningType.Error;
                uiArg.panelName = nameof(UIPanelWarningMessage);
                eventManager.Raise<UIWarningMessageController.Open>(uiArg);
                this.Release();
                //classPool.Return(req);
                return;

            }
            Debug.Log($"登录成功，Token={loginTask.Token}");

            var transition = await transitionProvider.InstantiateAsync(TransitionType.SMFadeTransition.ToString());
            // 并发开始
            var transitionOutTask = transition.TransitionOut();

            // 并发等待两者完成
            await UniTask.WhenAll(
                transitionOutTask.AsUniTask()
                //loginTask.AsUniTask()
            );

            // 获取登录结果
            var accountDTO = /*await*/ loginTask;
            var gameDTO = await httpRequest.RequestEnterGame(accountDTO);

            Debug.Log($"RequestEnterGame，Token={loginTask.Token}");

            //初始化必要模型
            playerModel.Initialize(gameDTO.PlayerDTO);
            levelModel.Initialize(gameDTO.LevelNodesDTO);
            samuraisModel.Initialize(gameDTO.SamuraisDTO);
            currenciesModel.Initialize(gameDTO.CurrencyDTO);
            formationDeployModel.Initialize(gameDTO.AtkFormationDTO);
            formationModel.Initialize(gameDTO.FormationDTOs);
            buildingModel.Initialize(gameDTO.BuildingDTOs);
            guideModel.Initialize(gameDTO.CurrentGuideBusinessId);
            hpPoolModel.Initialize(gameDTO.HpPoolDTO);

            gameDataManager.Login(gameDTO.ServerTime);

            string hubUrl = url.TrimEnd('/') + "/gamehub";
            await network.Connect(hubUrl, accountDTO.Token);

            //如果还没有过新手引导，则进入新手引导场景，否则进入城堡场景
            if (levelModel.IsLevelUnlocked("2"))
                await context.sm.SwitchToCastle(null);
            else
                await context.sm.SwitchToGuide(null);

            //await context.sm.SwitchToGame(null);

            await transition.TransitionIn();

            this.Release();
        }
    }


}
