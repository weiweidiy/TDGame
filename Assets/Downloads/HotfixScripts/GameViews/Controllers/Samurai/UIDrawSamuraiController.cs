using Adic;
using Adic.Container;
using Game.Common;
using Game.Share;
using GameCommands;
using JFramework;


namespace Tiktok
{
    public class UIDrawSamuraiController : ViewController
    {
        //public class Open : Event { }
        //public class Close : Event { }

        [Inject]
        IInjectionContainer container;
        //[Inject]
        //protected UIManager uiManager;
        [Inject]
        public UIDrawSamuraiController(EventManager eventManager) : base(eventManager)
        {
        }
        public override void OnStart()
        {
            base.OnStart();
            // 这里可以添加打开抽卡界面的逻辑
            eventManager.AddListener<Open>(OnDrawSamuraiOpen);
        }

        public override void OnStop()
        {
            base.OnStop();
            eventManager.RemoveListener<Open>(OnDrawSamuraiOpen);
        }

        protected override void DoOpen(Open e)
        {
            throw new System.NotImplementedException();
        }

        private void OnDrawSamuraiOpen(Open e)
        {
            //发送抽卡命令
            var dispatcher = container.GetCommandDispatcher();
            dispatcher.Dispatch<CommandDraw>(DrawSamuraiPoolType.Normal, 1);
        }
    }
}
