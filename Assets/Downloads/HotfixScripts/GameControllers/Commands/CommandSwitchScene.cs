using Adic;
using Adic.Container;
using JFramework;
using Tiktok;


namespace GameCommands
{
    public class CommandSwitchScene : Command
    {
        [Inject]
        IInjectionContainer container;

        [Inject]
        ITransitionProvider transitionProvider;
        public override async void Execute(params object[] parameters)
        {
            this.Retain();

            SceneType sceneType = (SceneType)parameters[0];
            object arg = parameters[1];

            var transition = await transitionProvider.InstantiateAsync(TransitionType.SMFadeTransition.ToString());
            // 并发开始
            await transition.TransitionOut();

            var context = container.Resolve<TiktokSceneSMContext>();

            switch (sceneType)
            {
                case SceneType.SceneCastle:
                    await context.sm.SwitchToCastle(arg);
                    break;
                case SceneType.SceneGame:
                    await context.sm.SwitchToGame(arg);
                    break;
                default:
                    throw new System.Exception("CommandSwitchScene: not support scene type " + sceneType.ToString());
            }

            await transition.TransitionIn();
            this.Release();
        }
    }


}
