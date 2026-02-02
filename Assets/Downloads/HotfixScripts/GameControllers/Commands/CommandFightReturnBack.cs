using Adic;
using Adic.Container;
using Game.Share;
using JFramework;
using Tiktok;


namespace GameCommands
{
    public class CommandFightReturnBack : Command
    {
        [Inject]
        IInjectionContainer container;

        [Inject]
        ITransitionProvider transitionProvider;

        [Inject]
        CombatViewController combatViewController;
        public override async void Execute(params object[] parameters)
        {
            this.Retain();

            var arg = (CombatSceneTransitionArg)parameters[0];
            var responseFight = arg.FightResponse;
            var sceneType = arg.SceneType;

            var transition = await transitionProvider.InstantiateAsync(TransitionType.SMFadeTransition.ToString());
            // 并发开始
            await transition.TransitionOut();

            combatViewController.Clear();

            var context = container.Resolve<TiktokSceneSMContext>();

            switch(sceneType)
            {
                case SceneType.SceneGame:
                    await context.sm.SwitchToGame(arg);
                    break;
                case SceneType.SceneGuide:
                    await context.sm.SwitchToGuide(arg);
                    break;
            }

            

            await transition.TransitionIn();


            this.Release();
        }
    }


}
