using Cysharp.Threading.Tasks;
using Game.Share;
using JFramework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Tiktok
{
    public class TiktokSceneSM : BaseSMAsync<TiktokSceneSMContext, BaseSceneState, TiktokSceneSMTrigger>
    {
        TiktokSceneInitState initState;
        TiktokSceneLoginState loginState;
        TiktokSceneGuideState guideState;
        TiktokSceneCastleState castleState;
        TiktokSceneGameState gameState;
        TiktokSceneCombatState combatState;

        SMConfig combatConfig;
        SMConfig gameConfig;
        SMConfig castleConfig;
        SMConfig guideConfig;

        protected override List<BaseSceneState> GetAllStates()
        {
            var states = new List<BaseSceneState>();

            initState = container.Resolve<TiktokSceneInitState>();
            if (initState == null)
                throw new Exception("Resolve TiktokSceneInitState is null");

            loginState = container.Resolve<TiktokSceneLoginState>();
            if (loginState == null)
                throw new Exception("Resolve TiktokSceneMenuState is null");

            guideState = container.Resolve<TiktokSceneGuideState>();
            if (guideState == null)
                throw new Exception("Resolve TiktokSceneGuideState is null");

            castleState = container.Resolve<TiktokSceneCastleState>();
            if (castleState == null)
                throw new Exception("Resolve TiktokSceneCastleState is null");

            gameState = container.Resolve<TiktokSceneGameState>();
            if (gameState == null)
                throw new Exception("Resolve TiktokSceneGameState is null");

            combatState = container.Resolve<TiktokSceneCombatState>();
            if (combatState == null)
                throw new Exception("Resolve TiktokSceneCombatState is null");

            states.Add(initState);
            states.Add(loginState);
            states.Add(guideState);
            states.Add(castleState);
            states.Add(gameState);
            states.Add(combatState);

            return states;
        }

        protected override Dictionary<string, SMConfig> GetConfigs()
        {
            var configs = new Dictionary<string, SMConfig>();

            var initName = initState.Name;
            var initConfig = new SMConfig();
            initConfig.state = initState;
            initConfig.dicPermit = new Dictionary<TiktokSceneSMTrigger, BaseSceneState>();
            initConfig.dicPermit.Add(TiktokSceneSMTrigger.Login, loginState);      
            configs.Add(initName, initConfig);


            var loginName = loginState.Name;
            var loginConfig = new SMConfig();
            loginConfig.state = loginState;
            loginConfig.dicPermit = new Dictionary<TiktokSceneSMTrigger, BaseSceneState>();
            loginConfig.dicPermit.Add(TiktokSceneSMTrigger.Game, gameState); // 可以进入游戏状态
            loginConfig.dicPermit.Add(TiktokSceneSMTrigger.Guide, guideState); // 可以进入新手引导状态
            loginConfig.dicPermit.Add(TiktokSceneSMTrigger.Castle, castleState); // 可以进入城堡状态
            configs.Add(loginName, loginConfig);


            var guideName = guideState.Name;
            guideConfig = new SMConfig();
            guideConfig.state = guideState;
            guideConfig.dicPermit = new Dictionary<TiktokSceneSMTrigger, BaseSceneState>();
            guideConfig.dicPermit.Add(TiktokSceneSMTrigger.Castle, castleState); // 可以进入城堡状态
            guideConfig.dicPermit.Add(TiktokSceneSMTrigger.Combat, combatState); // 可以进入战斗状态
            guideConfig.parameter = machine.SetTriggerParameters<object>(TiktokSceneSMTrigger.Guide);
            configs.Add(guideName, guideConfig);


            var castleName = castleState.Name;
            castleConfig = new SMConfig();
            castleConfig.state = castleState;
            castleConfig.dicPermit = new Dictionary<TiktokSceneSMTrigger, BaseSceneState>();
            castleConfig.dicPermit.Add(TiktokSceneSMTrigger.Game, gameState); // 可以进入游戏状态
            castleConfig.dicPermit.Add(TiktokSceneSMTrigger.Combat, combatState); // 可以进入战斗状态
            castleConfig.parameter = machine.SetTriggerParameters<object>(TiktokSceneSMTrigger.Castle);
            configs.Add(castleName, castleConfig);


            var gameName = gameState.Name;
            gameConfig = new SMConfig();
            gameConfig.state = gameState;
            gameConfig.dicPermit = new Dictionary<TiktokSceneSMTrigger, BaseSceneState>();
            gameConfig.dicPermit.Add(TiktokSceneSMTrigger.Combat, combatState); // 可以进入战斗状态
            gameConfig.dicPermit.Add(TiktokSceneSMTrigger.Castle, castleState); // 可以进入城堡状态
            gameConfig.parameter = machine.SetTriggerParameters<object>(TiktokSceneSMTrigger.Game);
            configs.Add(gameName, gameConfig);

            var combatName = combatState.Name;
            combatConfig = new SMConfig();
            combatConfig.state = combatState;
            combatConfig.dicPermit = new Dictionary<TiktokSceneSMTrigger, BaseSceneState>();
            combatConfig.dicPermit.Add(TiktokSceneSMTrigger.Game, gameState); // 可以返回到游戏状态
            combatConfig.dicPermit.Add(TiktokSceneSMTrigger.Castle, castleState); // 可以返回到城堡状态
            combatConfig.dicPermit.Add(TiktokSceneSMTrigger.Guide, guideState); // 可以返回到新手引导状态
            combatConfig.parameter = machine.SetTriggerParameters<object>(TiktokSceneSMTrigger.Combat);


            configs.Add(combatName, combatConfig);

            return configs;
        }

        public UniTask SwitchToLogin()
        {
            return machine.FireAsync(TiktokSceneSMTrigger.Login);
        }

        public UniTask SwitchToGame(object none)
        {
            return machine.FireAsync(gameConfig.parameter, none);
        }

        public UniTask SwitchToCombat(object responesFight)
        {
            return machine.FireAsync(combatConfig.parameter, responesFight);
        }

        public UniTask SwitchToGuide(object none)
        {
            return machine.FireAsync(guideConfig.parameter, none);
        }


        public UniTask SwitchToCastle(object none)
        {
            return machine.FireAsync(castleConfig.parameter, none);
        }
    }
}
