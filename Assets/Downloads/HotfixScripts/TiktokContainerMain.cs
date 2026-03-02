using Adic;
using Adic.Container;
using Cysharp.Threading.Tasks;
using JFramework;
using JFramework.Game;
using JFramework.Unity;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;




namespace Game
{
    /// <summary>
    /// 负责注册容器
    /// </summary>
    public class TiktokContainerMain : ContextRoot
    {
        IInjectionContainer container;

        public IInjectionContainer Container { get { return container; } }

        JFacade facade;

        public override void SetupContainers()
        {
            container = AddContainer<InjectionContainer>(/*ResolutionMode.RETURN_NULL*/)
                           .RegisterExtension<UnityBindingContainerExtension>()
                           .RegisterExtension<EventCallerContainerExtension>()
                           .RegisterExtension<CommanderContainerExtension>();



            container.Bind<GameViewControllerManager>().ToSingleton();

            container.Bind<View>().ToSingleton<UIPanelLoginView>().As(DemoSceneType.SceneLogin.ToString());

            container.Bind<View>().ToSingleton<BackgroundView>().As(DemoSceneType.SceneCastle.ToString());
            container.Bind<View>().ToSingleton<UIPanelStartMenuView>().As(DemoSceneType.SceneCastle.ToString());

            var assetsLoader = new YooAssetsLoader();
            var builder = new FacadeBuilder();

            builder.SetAssetsLoader(assetsLoader);
            builder.SetSceneStateMachine(new SceneSM());
            builder.SetFirstSceneState(DemoSceneType.SceneLogin.ToString());
            builder.SetViewControllerContainer(new GameViewControllerManager(container));
            builder.SetModelManager(new GameModelManager());
            builder.SetControllerManager(new GameControllerManager());
            builder.SetConfigManager(new GenConfigManager(assetsLoader, new DefaultDataConverter()));
            builder.SetGameAssetsQuary(new GameAssetsQuary());
            facade = builder.Build();

            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        }



        public override async void Init()
        {
            //Debug.Log("Init " + GameLauncher.ServerUrl + " / " + GameLauncher.Account);
            //var dispatcher = container.GetCommandDispatcher();
            //dispatcher.Dispatch<CommandStartupGame>();

            await facade.Run(configManager =>
            {
                var prefabDataList = configManager.GetAll<PrefabsCfgData>();
                var prefabNames = prefabDataList.Select(x => x.PrefabName).ToList();
                var taskPreloadGo = facade.PreloadGameObjects(prefabNames);

                var spriteDataList = configManager.GetAll<TexturesCfgData>();
                var spriteNames = spriteDataList.Select(x => x.Path).ToList();
                var taskPreloadSp = facade.PreloadSprites(spriteNames);

                return UniTask.WhenAll(taskPreloadGo, taskPreloadSp);
            });
        }

    }
}

//container.Bind<SceneSM>().ToSingleton<SceneSM>();
//container.Bind<SceneController>().ToSingleton<SceneController>();
//container.Bind<SceneTransitionController>().ToSingleton<SceneTransitionController>();
//container.Bind<BackgroundController>().ToSingleton<BackgroundController>();
//container.Bind<SlotsController>().ToSingleton<SlotsController>();
//container.Bind<WarriorControllerManager>().ToSingleton<WarriorControllerManager>();
//container.Bind<PlayerControllerManager>().ToSingleton<PlayerControllerManager>();

//container.Bind<LevelsManager>().ToSingleton();
//container.Bind<ITypeRegister>().ToSingleton<TiktokServerNetMessageRegister>().As("Server");
//container.Bind<IMessageTypeResolver>().ToSingleton<CommonServerJNetMessageTypeResolver>().As("Server");
//container.Bind<INetworkMessageProcessStrate>().ToSingleton<CommonServerJNetworkMessageProcessStrate>().As("Server");
//container.Bind<FakeServer>().ToSingleton();         
//container.Bind<FakeNotifier>().ToSingleton();


//container.Bind<BattleCalculator>().ToSingleton<BattleCalculator>();
//container.Bind<BattleSystem>().ToSingleton<BattleSystem>();

//container.RegisterCommand<CommandStartupGame>();
//container.RegisterCommand<CommandSwitchToBattleScene>();
//container.RegisterCommand<CommandNextBattleState>();




