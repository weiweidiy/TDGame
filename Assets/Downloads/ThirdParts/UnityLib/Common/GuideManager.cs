//using JFramework.Package;
using JFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

///游戏可以服用
namespace Game.Common
{
    /// <summary>
    /// 强制引导管理器，按顺序执行一系列的BaseRunable，每个Runable执行完后，执行下一个
    /// </summary>
    public class  GuideManager : BaseRunable
    {
        Queue<BaseRunable> guideQueue = new Queue<BaseRunable>();

        public void Enque(BaseRunable runable)
        {
            guideQueue.Enqueue(runable);
        }

        public void Enque(IEnumerable<BaseRunable> runables)
        {
            foreach (var runable in runables)
            {
                guideQueue.Enqueue(runable);
            }
        }

        void Clear()
        {
            guideQueue.Clear();
        }

        public override async Task Start(RunableExtraData extraData, TaskCompletionSource<bool> tcs = null)
        {
            if (IsRunning)
            {
                throw new Exception(this.GetType().ToString() + " is running , can't run again! ");
            }

            this.tcs = tcs == null ? new TaskCompletionSource<bool>() : tcs;

            this.ExtraData = extraData;
            this.IsRunning = true;

            await RunNext(ExtraData);

            await this.tcs.Task;
        }

        protected override void OnStop()
        {
            base.OnStop();
            //调用队列的onstop
            foreach (var runable in guideQueue)
            {
                if (runable.IsRunning)
                {
                    runable.Stop();
                }
            }
            Clear();
        }

        private async Task RunNext(RunableExtraData extraData)
        {
            while (true)
            {
                if (guideQueue.Count == 0)
                {
                    IsRunning = false;
                    tcs.SetResult(true);
                    return;
                }
                var runable = guideQueue.Dequeue();
                await runable.Start(extraData);
            }           
        }

 
    }
}
