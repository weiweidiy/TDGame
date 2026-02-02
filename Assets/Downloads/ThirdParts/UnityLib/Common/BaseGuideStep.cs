//using JFramework.Package;
using Adic;
using JFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

///游戏可以服用
namespace Game.Common
{
    public abstract class BaseGuideStep : BaseRunable
    {

        public List<BaseEventTrigger> StartTriggers { get; set; } = new List<BaseEventTrigger>();
        public BaseEventTrigger CompleteTrigger { get; set; }

        [Inject]
        protected EventManager eventManager;

        protected override void OnStart(RunableExtraData extraData)
        {
            base.OnStart(extraData);

            if (CompleteTrigger != null)
            {
                CompleteTrigger.AddListeners();
                CompleteTrigger.onTrigger += OnCompleteTrigger;
            }
            else
                throw new Exception("CompleteTrigger不能为空");


            if (StartTriggers == null || StartTriggers.Count == 0)
            {
                Execute(extraData);
                return;
            }
            else
            {
                foreach(var trigger in StartTriggers)
                {
                    trigger.onTrigger += Trigger_onTrigger;
                    trigger.AddListeners();
                }
            }
        }



        protected override void OnStop()
        {
            base.OnStop();

            if (CompleteTrigger != null)
            {
                CompleteTrigger.RemoveListeners();
                CompleteTrigger.onTrigger -= OnCompleteTrigger;
            }

            if (StartTriggers == null || StartTriggers.Count == 0)
                return;
            else
            {
                foreach (var trigger in StartTriggers)
                {
                    trigger.onTrigger -= Trigger_onTrigger;
                    trigger.RemoveListeners();
                }
            }

        }

        private void Trigger_onTrigger(object arg)
        {
            Execute(arg);
        }

        protected virtual void OnCompleteTrigger(object arg)
        {
            if (ExtraData == null)
                ExtraData = new RunableExtraData();

            if (arg != null)
                ExtraData.Data = arg;

            Stop();
        }

        protected abstract void Execute(object arg);
    }
}
