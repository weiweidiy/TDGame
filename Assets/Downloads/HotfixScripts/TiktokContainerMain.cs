using Adic;
using Adic.Container;
using GameCommands;
using Stateless;
using Tiktok;
using UnityEngine;
using JFramework;
using JFramework.Common;
using JFramework.Extern;
using Game.Common;
using JFramework.Package;
using JFramework.Game;
using System;
using System.Net;
using Game.Share;


namespace Tiktok
{
    /// <summary>
    /// 负责注册容器
    /// </summary>
    public class TiktokContainerMain : ContextRoot
    {
        IInjectionContainer container;

        public IInjectionContainer Container { get { return container; } }

        public override void SetupContainers()
        {
            container = AddContainer<InjectionContainer>(/*ResolutionMode.RETURN_NULL*/)
                           .RegisterExtension<UnityBindingContainerExtension>()
                           .RegisterExtension<EventCallerContainerExtension>()
                           .RegisterExtension<CommanderContainerExtension>();


            container.Bind<string>().To(TiktokLauncher.ServerUrl).As("ServerUrl");
            container.Bind<string>().To(TiktokLauncher.Account).As("Account");

            ////绑定通用工具类(无依赖)~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //container.Bind<PrefabLocation>().ToSingleton<PrefabLocation>();
            //container.Bind<WarriorAnimation>().ToSingleton<WarriorAnimation>();
            container.Bind<Utility>().ToSingleton();

            container.Bind<IAssetsLoader>().ToSingleton<YooAssetsLoader>();
            container.Bind<ITypeRegister>().ToSingleton<TiktokClassRegister>();
            container.Bind<IObjectPool>().ToSingleton<CommonClassPool>();
            container.Bind<EventManager>().ToSingleton<CommonEventManager>();
            container.Bind<ITimerUtils>().ToSingleton<DotweenUtils>();
            container.Bind<ITransitionProvider>().ToSingleton<SMTransitionProvider>();
            container.Bind<IConfigLoader>().ToSingleton<YooAssetsLoader>();
            container.Bind<IDataConverter>().ToSingleton<LitJsonSerializer>();
            container.Bind<IDeserializer>().ToSingleton<JsonNetSerializer>();
            container.Bind<ISerializer>().ToSingleton<LitJsonSerializer>();
            container.Bind<TiktokUnityHttpRequest>().ToSingleton();
            container.Bind<IGameAudioManager>().ToSingleton<GameAudioManager>();

            //绑定配置表管理类 dependence : IConfigLoader,IDeserializer
            container.Bind<IJConfigManager>().ToSingleton<TiktokGenConfigManager>();
            container.Bind<TiktokConfigManager>().ToSingleton();




            //绑定存档管理器 dependence : IDataConverter
            container.Bind<IDataManager>().ToSingleton<UnityPrefDataManager>();
            container.Bind<IGameDataStore>().ToSingleton<CommonDataStore>();

            //绑定网络类
            container.Bind<ITypeRegister>().ToSingleton<TiktokClientNetMessageRegister>().As("Client");
            container.Bind<IMessageTypeResolver>().ToSingleton<CommonClientJNetMessageTypeResolver>().As("Client");
            container.Bind<INetMessageSerializerStrate>().ToSingleton<CommonJNetMessageJsonSerializerStrate>();
            container.Bind<INetworkMessageProcessStrate>().ToSingleton<CommonClientJNetworkMessageProcessStrate>().As("Client");
            container.Bind<IJSocket>().To<SignalRSocket>();
            //container.Bind<IJSocket>().To<FakeSocket>();
            container.Bind<ISocketFactory>().ToSingleton<SocketFactory>();
            container.Bind<IJTaskCompletionSourceManager<IUnique>>().To<JTaskCompletionSourceManager<IUnique>>();
            container.Bind<IJNetwork>().ToSingleton<CommonClientJNetwork>();



            ///依赖BaseClassPool
            //container.Bind<CommonEventManager>().ToSingleton();

            ////绑定通用逻辑
            //container.Bind<GameObjectManager>().ToSingleton<MyGameObjectPool>();
            //container.Bind<ITransitionProvider>().ToSingleton<SMTransitionProvider>();



            ////绑定模型~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            Func<LevelNodeDTO, string> func = (node) => node.BusinessId.ToString();
            container.Bind<Func<LevelNodeDTO, string>>().To(func);
            Func<SamuraiDTO, string> func2 = (data) => data.Id.ToString();
            container.Bind<Func<SamuraiDTO, string>>().To(func2);
            Func<CurrencyDTO, string> func3 = (data) => data.CurrencyType.ToString();
            container.Bind<Func<CurrencyDTO, string>>().To(func3);
            Func<ILanguage, string> func4 = (lang) => lang.GetHashCode().ToString();
            container.Bind<Func<ILanguage, string>>().To(func4);
            Func<FormationDeployDTO, string> func5 = (data) => data.Id.ToString();
            container.Bind<Func<FormationDeployDTO, string>>().To(func5);
            Func<FormationDTO, string> func6 = (data) => data.FormationType.ToString();
            container.Bind<Func<FormationDTO, string>>().To(func6);
            Func<BuildingDTO, string> func7 = (data) => data.BusinessId.ToString();
            container.Bind<Func<BuildingDTO, string>>().To(func7);

            //语言包
            container.Bind<ILanguage>().ToSingleton<LanguageSC>();
            container.Bind<ILanguage>().ToSingleton<LanguageTC>();
            container.Bind<ILanguageManager>().ToSingleton<CommonLanguageManager>();

            ///依赖CommonEventManager
            container.Bind<LevelsModel>().ToSingleton();
            container.Bind<PlayerModel>().ToSingleton();
            container.Bind<SamuraisModel>().ToSingleton();
            container.Bind<CurrenciesModel>().ToSingleton();
            container.Bind<FormationDeployModel>().ToSingleton();
            container.Bind<FormationModel>().ToSingleton();
            container.Bind<BuildingModel>().ToSingleton();
            container.Bind<CurrentGuideStepModel>().ToSingleton();
            container.Bind<HpPoolModel>().ToSingleton();

            //数据管理器，同一处理查询数据
            container.Bind<TiktokGameDataManager>().ToSingleton();

            ////绑定视图controller~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            ///依赖IAssetsLoader
            container.Bind<TiktokGameObjectPool>().ToSingleton();
            container.Bind<TiktokGameObjectManager>().ToSingleton();
            ///依赖IAssetsLoader
            container.Bind<UIManager>().ToSingleton();
            container.Bind<TiktokSpritesManager>().ToSingleton();

            //视图数据转换
            container.Bind<UIScrollerUnitViewDataConverter>().ToSingleton();


            //战斗需要用的类
            container.Bind<IJCombatAnimationPlayer>().To<TiktokJCombatAnimationPlayer>();
            container.Bind<TiktokCombatPlayer>().ToSelf();


            //登录相关视图
            BindingLoginControllers();
            //引导相关视图
            BindingGuideControllers();
            //基础关卡相关视图
            BindingLevelControllers();
            //因为和Level有继承关系，所以只需要绑定额外的控制器
            BindingGameLevelControllers();
            //绑定战斗相关控制器
            BindingCombatControllers();
            //城堡相关控制器
            BindingCastleControllers();



            //每次都是新的实例
            container.Bind<ParallelLauncher>().ToSelf();
            //其他UI
            container.Bind<TiktokNetworkHolding>().ToSingleton();


            //新手引导
            BindingGuideSteps();



            //绑定系统
            container.Bind<TiktokSceneInitState>().ToSingleton();
            container.Bind<TiktokSceneLoginState>().ToSingleton();
            container.Bind<TiktokSceneGuideState>().ToSingleton();
            container.Bind<TiktokSceneCastleState>().ToSingleton();
            container.Bind<TiktokSceneGameState>().ToSingleton();
            container.Bind<TiktokSceneCombatState>().ToSingleton();
            container.Bind<TiktokSceneSMContext>().ToSingleton();
            container.Bind<TiktokSceneSM>().ToSingleton();


            //其他对象
            container.Bind<UIWarningMessageController.ControllerArgs>().ToSelf();

            ////绑定命令
            container.RegisterCommands("GameCommands");


            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        }



        void BindingLoginControllers()
        {
            container.Bind<ViewController>().ToSingleton<UIWarningMessageController>().As("Login");
            container.Bind<ViewController>().ToSingleton<UILoginController>().As("Login");
        }

        void BindingLevelControllers()
        {
            container.Bind<ViewController>().ToSingleton<UIWarningMessageController>().As("Level");

            //关卡相关视图
            container.Bind<ViewController>().ToSingleton<GameLevelBackgroundViewController>().As("Level");
            container.Bind<ViewController>().ToSingleton<GameLevelNodeViewController>().As("Level");
            //container.Bind<ViewController>().ToSingleton<UIGameLevelController>().As("Level");
            container.Bind<ViewController>().ToSingleton<GameLevelNodeBottomViewController>().As("Level");
            container.Bind<ViewController>().ToSingleton<GameLevelNodeStarViewController>().As("Level");
            container.Bind<ViewController>().ToSingleton<UILevelNodeDetailController>().As("Level");
            container.Bind<ViewController>().ToSingleton<UILevelNodeMenuController>().As("Level");
            container.Bind<ViewController>().ToSingleton<GameLevelCombatResultController>().As("Level");
            container.Bind<ViewController>().ToSingleton<UICurrenciesController>().As("Level");
            container.Bind<ViewController>().ToSingleton<UIDeployController>().As("Level");
            //主菜单
            container.Bind<ViewController>().ToSingleton<UIMainMenuController>().As("Level");

            //奖励
            container.Bind<ViewController>().ToSingleton<UIRewardController>().As("Level");
            container.Bind<ViewController>().ToSingleton<NetworkMessageListener>().As("Level");
            container.Bind<ViewController>().ToSingleton<EventIntercepter>().As("Level");
        }

        /// <summary>
        /// 子类的控制器，和Level有继承关系
        /// </summary>
        void BindingGameLevelControllers()
        {
            //自动会包含所有 Level的controller
            //武将列表
            container.Bind<ViewController>().ToSingleton<UISamuraisListController>().As("Game");
            //container.Bind<ViewController>().ToSingleton<UIDrawSamuraiController>().As("Game");
            //抽卡
            container.Bind<ViewController>().ToSingleton<UIKachaController>().As("Game");
        }

        void BindingCombatControllers()
        {
            //战斗
            container.Bind<ViewController>().ToSingleton<CombatViewController>().As("Combat");
            container.Bind<ViewController>().ToSingleton<UICombatUnitBarController>().As("Combat");
        }

        void BindingCastleControllers()
        {
            container.Bind<ViewController>().ToSingleton<NetworkMessageListener>().As("Castle");
            container.Bind<ViewController>().ToSingleton<UIWarningMessageController>().As("Castle");
            container.Bind<ViewController>().ToSingleton<CastleBackgroundViewController>().As("Castle");
            container.Bind<ViewController>().ToSingleton<CastleBuildingsViewController>().As("Castle");
            container.Bind<ViewController>().ToSingleton<UIBuildingMenuController>().As("Castle");

            container.Bind<ViewController>().ToSingleton<UICurrenciesController>().As("Castle");
            container.Bind<ViewController>().ToSingleton<UIMainMenuController>().As("Castle");
            container.Bind<ViewController>().ToSingleton<UISamuraisListController>().As("Castle");
            //container.Bind<ViewController>().ToSingleton<UIDrawSamuraiController>().As("Castle");
            container.Bind<ViewController>().ToSingleton<UIKachaController>().As("Castle");
            container.Bind<ViewController>().ToSingleton<UIDeployController>().As("Castle");
            container.Bind<ViewController>().ToSingleton<UILevelListController>().As("Castle");
            container.Bind<ViewController>().ToSingleton<UIHpPoolController>().As("Castle");
        }

        void BindingGuideControllers()
        {
            container.Bind<ViewController>().ToSingleton<UIGuideController>().As("Guide");
            container.Bind<ViewController>().ToSingleton<UIDialogController>().As("Guide");
            container.Bind<ViewController>().ToSingleton<UIUnlockController>().As("Guide");
        }

        private void BindingGuideSteps()
        {

            container.Bind<EventTriggerLevelEnter>().ToSelf();
            container.Bind<EventTriggerDialogCompleted>().ToSelf();
            container.Bind<EventTriggerLevelNodeClicked>().ToSelf();
            container.Bind<EventTriggerLevelNodeEntranceShow>().ToSelf();
            container.Bind<EventTriggerLevelNodeConfirmed>().ToSelf();
            container.Bind<EventTriggerLevelNodeShow>().ToSelf();
            container.Bind<EventTriggerRewardReceived>().ToSelf();
            container.Bind<EventTriggerMainMenuShow>().ToSelf();
            container.Bind<EventTriggerDeployShow>().ToSelf();
            container.Bind<EventTriggerDeployUpdate>().ToSelf();
            container.Bind<EventTriggerDeployHide>().ToSelf();
            container.Bind<EventTriggerMainMenuGet>().ToSelf();

            container.Bind<GuideManager>().ToSingleton();
            container.Bind<StepMaskLevelNode>().ToSelf();
            container.Bind<StepMaskUIObject>().ToSelf();
            container.Bind<StepShowSamuraiReward>().ToSelf();
            container.Bind<StepDialog>().ToSelf();
            container.Bind<StepUnlockSystem>().ToSelf();
        }

        public override void Init()
        {
            Debug.Log("Init " + TiktokLauncher.ServerUrl + " / " + TiktokLauncher.Account);
            var dispatcher = container.GetCommandDispatcher();

            dispatcher.Dispatch<CommandStartupGame>();

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




