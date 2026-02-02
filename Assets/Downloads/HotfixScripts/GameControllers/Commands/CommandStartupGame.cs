using Adic;
using Adic.Container;
using Cysharp.Threading.Tasks;
using Game.Common;
using JFramework;
using JFramework.Game;
using System;
using System.Collections.Generic;
using Tiktok;
using UnityEngine;


namespace GameCommands
{

    /// <summary>
    /// 运行游戏，只会运行1次, 容器注册完成后调用
    /// </summary>
    public class CommandStartupGame : Command
    {
        [Inject]
        IInjectionContainer container;

        [Inject]
        IAssetsLoader assetsLoader;

        /// <summary>
        /// 普通类对象池
        /// </summary>
        [Inject]
        IObjectPool classPool;

        /// <summary>
        /// 游戏场景对象管理器
        /// </summary>
        [Inject]
        TiktokGameObjectManager gameObjectManager;


        [Inject]
        IJConfigManager jConfigManager;

        [Inject]
        ILanguageManager languageManager;

        [Inject]
        IGameAudioManager gameAudioManager;

        [Inject]
        TiktokSpritesManager tiktokSpritesManager;

        /// <summary>
        /// 设置这个命令只有1个实例（无状态的）
        /// </summary>
        public override bool singleton { get { return true; } }


        public async override void Execute(params object[] parameters)
        {
            Debug.Log("CommandStartupGame");

            CheckInject();

            this.Retain();

            InitializeTools(); //1次启动游戏 只会初始化1次

            InitializeModels(); //1次启动游戏 只会初始化1次

            await InitializeViews(); //1次启动游戏 只会初始化1次

            this.Release();
        }

        /// <summary>
        /// 初始化工具
        /// </summary>
        void InitializeTools()
        {
            //普通类对象池初始化，注册类
            gameAudioManager.Initialize();


        }

        /// <summary>
        /// 初始化模型，一般用不上，数据都需要等登录请求后初始化
        /// </summary>
        void InitializeModels()
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        async UniTask InitializeViews()
        {
            Debug.Log("InitializeViews");
            //切换场景
            var sm = container.Resolve<TiktokSceneSM>();
            var context = container.Resolve<TiktokSceneSMContext>();
            context.sm = sm;
            sm.Initialize(context);

            //加载配置表        
            await jConfigManager.PreloadAllAsync();
            //初始化游戏对象管理器
            var tasks = new List<UniTask>();
            tasks.Add(gameObjectManager.Initialize());
            //tasks.Add(tiktokSpritesManager.Initialize());
            await UniTask.WhenAll(tasks);

            await sm.SwitchToLogin();
        }

        /// <summary>
        /// 检查注入
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        void CheckInject()
        {
            if (assetsLoader == null)
                throw new System.Exception(this.GetType().ToString() + " Inject IAssetsLoader failed!");

            if (classPool == null)
                throw new System.Exception(this.GetType().ToString() + " Inject BaseClassPool failed!");

        }
    }


}
