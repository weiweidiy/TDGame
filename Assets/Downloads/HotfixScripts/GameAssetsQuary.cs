using Cysharp.Threading.Tasks;
using JFramework.Game;
using JFramework.Unity;
using UnityEngine;




namespace Game
{
    public class GameAssetsQuary : IGameAssetsQuary
    {

        IJConfigManager configManager;

        IModelManager modelManager;

        ISpriteManager spriteManager;


        public void SetFacade(IJFacade facade)
        {
            configManager = facade.GetConfigManager();
            modelManager = facade.GetModelManager();
            spriteManager = facade.GetSpriteManager();
        }

        public UniTask<Sprite> GetBackgroundSpriteAsync()
        {
            if(spriteManager == null)
            {
                Debug.LogError("SpriteManager is null 请调用SetFacade 设置facade");
                return UniTask.FromResult<Sprite>(null);
            }
            var spName = "4pd_img_background_lobby_1";
            var sp = spriteManager.GetSprite(spName);

            return UniTask.FromResult(sp);
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




