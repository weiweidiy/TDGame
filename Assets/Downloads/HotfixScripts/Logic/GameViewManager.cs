using Adic;
using Adic.Container;
using JFramework.Unity;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class GameViewManager : BaseViewManager
    {
        IInjectionContainer container;

        [Inject]
        public GameViewManager(IInjectionContainer container) 
        {
            this.container = container;
        }

        public override void RegisterViewControllers()
        {
            if (!viewControllers.ContainsKey(DemoSceneType.SceneLogin.ToString()))
            {
                viewControllers.Add(DemoSceneType.SceneLogin.ToString(), new List<View>());
            }

            if (!viewControllers.ContainsKey(DemoSceneType.SceneCastle.ToString()))
            {
                viewControllers.Add(DemoSceneType.SceneCastle.ToString(), new List<View>());
            }


            var sceneLoginViews = container.ResolveAll<View>(DemoSceneType.SceneLogin.ToString());
            foreach (var view in sceneLoginViews)
            {
                viewControllers[DemoSceneType.SceneLogin.ToString()].Add(view);
            }

            var sceneCastleViews = container.ResolveAll<View>(DemoSceneType.SceneCastle.ToString());
            foreach (var view in sceneCastleViews)
            {
                viewControllers[DemoSceneType.SceneCastle.ToString()].Add(view);
            }

        }
    }

}