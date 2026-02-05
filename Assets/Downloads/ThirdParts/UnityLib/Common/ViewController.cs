using JFramework;

///游戏可以服用
namespace Game.Common
{
    /// <summary>
    /// 视图控制器基类
    /// </summary>
    public abstract class ViewController
    {
        /// <summary>
        /// 开启视图命令
        /// </summary>
        public class Open : Event { }
        /// <summary>
        /// 关闭视图事件
        /// </summary>
        public class Close : Event { }

        /// <summary>
        /// 控制器参数
        /// </summary>
        public class ControllerBaseArgs
        {
            //通用参数
            public string panelName; //面板名字
        }

        /// <summary>
        /// 事件管理器
        /// </summary>
        protected EventManager eventManager;

        /// <summary>
        /// UI管理器
        /// </summary>
       // [Inject]
        protected UIManager uiManager;

        /// <summary>
        /// 发送事件
        /// </summary>
        ///// <typeparam name="T"></typeparam>
        /// <param name="arg"></param>
        protected void SendEvent<T>(object arg) where T : Event, new()
        {
            eventManager.Raise<T>(arg);
        }

        public ViewController(EventManager eventManager) 
        {
            this.eventManager = eventManager;
        }

        public ViewController(EventManager eventManager, UIManager uIManager) : this(eventManager)
        {
            this.uiManager = uIManager;
        }

        /// <summary>
        /// 启动时候调用（表示创建完成，需要打开视图，需要调用事件系统Open事件）
        /// </summary>
        public virtual void OnStart()
        {
            eventManager.AddListener<Open>(DoOpen);
            eventManager.AddListener<Close>(DoClose);
        }

        /// <summary>
        /// 关闭时候调用
        /// </summary>
        public virtual void OnStop()
        {
            eventManager.RemoveListener<Open>(DoOpen);
            eventManager.AddListener<Close>(DoClose);
        }


        /// <summary>
        /// 实际打开视图的方法，Open中会带controllerArgs
        /// </summary>
        /// <param name="e"></param>
        protected abstract void DoOpen(Open e);

        protected virtual void DoClose(Close e) { }
    }
}
