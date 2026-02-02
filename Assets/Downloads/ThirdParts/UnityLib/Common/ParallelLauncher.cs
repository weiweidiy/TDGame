//using JFramework.Package;
using System.Collections.Generic;
using System;
using Adic;
using JFramework;
using JFramework.Game;
using Cysharp.Threading.Tasks;

///游戏可以服用
namespace Game.Common
{

    /// <summary>
    /// 并行执行器
    /// </summary>
    public class ParallelLauncher : ViewController
    {
        /// <summary>
        /// 内部运行对象
        /// </summary>

        protected List<ViewController> internalRunables;

        [Inject]
        public ParallelLauncher(EventManager eventManager) : base(eventManager)
        {
        }

        public void Add(ViewController runable)
        {
            if (internalRunables == null)
                internalRunables = new List<ViewController>();

            internalRunables.Add(runable);
        }

        public int Count()
        {
            if (internalRunables == null)
                return 0;
            return internalRunables.Count;
        }

        public void Clear()
        {
            if (internalRunables != null)
            {
                foreach (var runable in internalRunables)
                {
                    runable.OnStop();
                }
                internalRunables.Clear();
            }
        }


        /// <summary>
        /// 运行
        /// </summary>
        public override void OnStart()
        {

            base.OnStart();
            foreach (var runable in this.internalRunables)
            {
                runable.OnStart();

            }
        }

        public override void OnStop()
        {
            base.OnStop();
            foreach (var runable in this.internalRunables)
            {
                runable.OnStop();
            }
        }

        protected override void DoOpen(Open e)
        {
            
        }
    }
}
