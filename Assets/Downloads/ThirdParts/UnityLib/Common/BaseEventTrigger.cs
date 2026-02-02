//using JFramework.Package;
using Adic;
using JFramework;
using System;

///游戏可以服用
namespace Game.Common
{
    public abstract class BaseEventTrigger
    {
        public event Action<object> onTrigger;
      

        [Inject]
        protected EventManager eventManager;
        public abstract void AddListeners();
        public abstract void RemoveListeners();

        protected void Trigger(object arg)
        {
            onTrigger?.Invoke(arg);
        }

    }
}
