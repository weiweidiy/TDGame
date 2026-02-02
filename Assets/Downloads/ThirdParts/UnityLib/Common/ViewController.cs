//using JFramework.Package;
using Adic;
using JFramework;
using System;

///游戏可以服用
namespace Game.Common
{
    public abstract class ViewController
    {
        public class Open : Event { }
        public class Close : Event { }

        public class ControllerBaseArgs
        {
            //通用参数
            public string panelName; //面板名字
        }
        protected EventManager eventManager;
        [Inject]
        protected UIManager uiManager;

        protected void SendEvent<T>(object arg) where T : Event, new()
        {
            eventManager.Raise<T>(arg);
        }

        public ViewController(EventManager eventManager) 
        {
            this.eventManager = eventManager;
        }

        public virtual void OnStart()
        {
            eventManager.AddListener<Open>(DoOpen);
            eventManager.AddListener<Close>(DoClose);
        }

        public virtual void OnStop()
        {
            eventManager.RemoveListener<Open>(DoOpen);
            eventManager.AddListener<Close>(DoClose);
        }



        protected abstract void DoOpen(Open e);

        protected virtual void DoClose(Close e) { }
    }
}
