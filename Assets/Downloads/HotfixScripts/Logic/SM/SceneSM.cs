using Cysharp.Threading.Tasks;
using Game.Demo;
using JFramework;
using JFramework.Unity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Game
{
    public enum DemoSceneType
    {
        None = 0,
        Init,
        SceneLogin,
        SceneGuide,
        SceneGame,
        SceneCombat,
        SceneCastle,
    }

    public enum DemoSceneSMTrigger
    {
        Login,
        Game,
        Guide,
        Combat,
        Castle,
    }

    public abstract class BaseSceneState : BaseSceneState<DemoSceneType>
    {

    }


    public class SceneSM : BaseSMAsync<BaseSceneState, DemoSceneSMTrigger>
    {
        SceneInitState initState;
        SceneLoginState loginState;
        //TiktokSceneGuideState guideState;
        SceneCastleState castleState;
        //TiktokSceneGameState gameState;
        //TiktokSceneCombatState combatState;

        //如果需要在状态切换时传递参数，可以在这里定义对应的SMConfig
        //SMConfig combatConfig;
        //SMConfig gameConfig;
        SMConfig castleConfig;
        //SMConfig guideConfig;


        protected override List<BaseSceneState> GetAllStates()
        {
            var states = new List<BaseSceneState>();

            initState = new SceneInitState();
            if (initState == null)
                throw new Exception("Resolve DefaultSceneInitState is null");

            loginState = new SceneLoginState();
            if (loginState == null)
                throw new Exception("Resolve TiktokSceneMenuState is null");

            //guideState = container.Resolve<TiktokSceneGuideState>();
            //if (guideState == null)
            //    throw new Exception("Resolve TiktokSceneGuideState is null");

            castleState = new SceneCastleState();
            if (castleState == null)
                throw new Exception("Resolve TiktokSceneCastleState is null");

            //gameState = container.Resolve<TiktokSceneGameState>();
            //if (gameState == null)
            //    throw new Exception("Resolve TiktokSceneGameState is null");

            //combatState = container.Resolve<TiktokSceneCombatState>();
            //if (combatState == null)
            //    throw new Exception("Resolve TiktokSceneCombatState is null");

            states.Add(initState);
            states.Add(loginState);
            //states.Add(guideState);
            states.Add(castleState);
            //states.Add(gameState);
            //states.Add(combatState);

            return states;
        }



        protected override Dictionary<string, SMConfig> GetConfigs()
        {
            var configs = new Dictionary<string, SMConfig>();

            var initName = initState.Name;
            var initConfig = new SMConfig();
            initConfig.state = initState;
            initConfig.dicPermit = new Dictionary<DemoSceneSMTrigger, BaseSceneState>();
            initConfig.dicPermit.Add(DemoSceneSMTrigger.Login, loginState);
            configs.Add(initName, initConfig);


            var loginName = loginState.Name;
            var loginConfig = new SMConfig();
            loginConfig.state = loginState;
            loginConfig.dicPermit = new Dictionary<DemoSceneSMTrigger, BaseSceneState>();
            //loginConfig.dicPermit.Add(DefaultSceneSMTrigger.Game, gameState); // 可以进入游戏状态
            //loginConfig.dicPermit.Add(DefaultSceneSMTrigger.Guide, guideState); // 可以进入新手引导状态
            loginConfig.dicPermit.Add(DemoSceneSMTrigger.Castle, castleState); // 可以进入城堡状态
            configs.Add(loginName, loginConfig);


            //var guideName = guideState.Name;
            //guideConfig = new SMConfig();
            //guideConfig.state = guideState;
            //guideConfig.dicPermit = new Dictionary<DefaultSceneSMTrigger, BaseSceneState>();
            //guideConfig.dicPermit.Add(DefaultSceneSMTrigger.Castle, castleState); // 可以进入城堡状态
            //guideConfig.dicPermit.Add(DefaultSceneSMTrigger.Combat, combatState); // 可以进入战斗状态
            //guideConfig.parameter = machine.SetTriggerParameters<object>(DefaultSceneSMTrigger.Guide);
            //configs.Add(guideName, guideConfig);


            var castleName = castleState.Name;
            castleConfig = new SMConfig();
            castleConfig.state = castleState;
            castleConfig.dicPermit = new Dictionary<DemoSceneSMTrigger, BaseSceneState>();
            //castleConfig.dicPermit.Add(DemoSceneSMTrigger.Game, gameState); // 可以进入游戏状态
            //castleConfig.dicPermit.Add(DemoSceneSMTrigger.Combat, combatState); // 可以进入战斗状态
            castleConfig.parameter = machine.SetTriggerParameters<object>(DemoSceneSMTrigger.Castle);
            configs.Add(castleName, castleConfig);


            //var gameName = gameState.Name;
            //gameConfig = new SMConfig();
            //gameConfig.state = gameState;
            //gameConfig.dicPermit = new Dictionary<DefaultSceneSMTrigger, BaseSceneState>();
            //gameConfig.dicPermit.Add(DefaultSceneSMTrigger.Combat, combatState); // 可以进入战斗状态
            //gameConfig.dicPermit.Add(DefaultSceneSMTrigger.Castle, castleState); // 可以进入城堡状态
            //gameConfig.parameter = machine.SetTriggerParameters<object>(DefaultSceneSMTrigger.Game);
            //configs.Add(gameName, gameConfig);

            //var combatName = combatState.Name;
            //combatConfig = new SMConfig();
            //combatConfig.state = combatState;
            //combatConfig.dicPermit = new Dictionary<DefaultSceneSMTrigger, BaseSceneState>();
            //combatConfig.dicPermit.Add(DefaultSceneSMTrigger.Game, gameState); // 可以返回到游戏状态
            //combatConfig.dicPermit.Add(DefaultSceneSMTrigger.Castle, castleState); // 可以返回到城堡状态
            //combatConfig.dicPermit.Add(DefaultSceneSMTrigger.Guide, guideState); // 可以返回到新手引导状态
            //combatConfig.parameter = machine.SetTriggerParameters<object>(DefaultSceneSMTrigger.Combat);
            //configs.Add(combatName, combatConfig);


            return configs;
        }


        public override UniTask SwitchToState(string stateName, GameContext context)
        {
            var task = base.SwitchToState(stateName, context);

            if (stateName == DemoSceneType.SceneLogin.ToString())
                return SwitchToLogin();

            if (stateName == DemoSceneType.SceneCastle.ToString())
                return SwitchToCastle(null);

            return task;
        }



        UniTask SwitchToLogin()
        {
            //UnityEngine.Debug.Log("Switching to Login State");
            return machine.FireAsync(DemoSceneSMTrigger.Login);
        }

        UniTask SwitchToCastle(object none)
        {
            return machine.FireAsync(castleConfig.parameter, none);
        }
    }
}
