using Adic;
using Adic.Container;
using Game.Common;
using Game.Share;
using GameCommands;
using JFramework;
using JFramework.Game;
using JFramework.Game.View;
using System;
using System.Threading.Tasks;
using UnityEngine;


namespace Tiktok
{
    public class CombatViewController : ViewController
    {
        public class  ControllerArgs : ControllerBaseArgs
        {
            public CombatSceneTransitionArg arg;
        }

        [Inject]
        IInjectionContainer container;
        [Inject]
        protected TiktokGameObjectManager gameObjectManager;
        [Inject]
        protected GameLevelBackgroundViewController gameLevelViewController;
        [Inject]
        protected TiktokConfigManager jConfigManager;

        [Inject]
        protected LevelsModel levelsModel;

        ResponseFight fightDTO = null;

        TiktokCombatPlayer combatPlayer;


        [Inject]
        public CombatViewController(EventManager eventManager) : base(eventManager)
        {

        }
        public override void OnStart()
        {
            base.OnStart();
            //eventManager.AddListener<EventStartCombat>(OnCombatStart);
            eventManager.AddListener<UIPanelEventCloseBtnClicked>(OnExitComatClicked);
        }


        public override void OnStop()
        {
            base.OnStop();
            //eventManager.RemoveListener<EventStartCombat>(OnCombatStart);
            eventManager.RemoveListener<UIPanelEventCloseBtnClicked>(OnExitComatClicked);
        }
        protected async override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            var arg = controllerArgs.arg;
            fightDTO = arg.FightResponse;

            combatPlayer = container.Resolve<TiktokCombatPlayer>();

            combatPlayer.LoadReportData(fightDTO.ReportData);
            await combatPlayer.Play();
        }


        //private async void OnCombatStart(EventStartCombat e)
        //{
        //    var arg = e.Body as CombatSceneTransitionArg;
        //    fightDTO = arg.FightResponse;

        //    combatPlayer = container.Resolve<TiktokCombatPlayer>();

        //    combatPlayer.LoadReportData(fightDTO.ReportData);
        //    await combatPlayer.Play();

        //}

        private void OnExitComatClicked(UIPanelEventCloseBtnClicked e)
        {
            var panelData = e.Body as UIPanelCombatResult.UIPanelCombatResultPanelData;
            if(panelData == null) return;

            eventManager.Raise<EventExitCombat>(null);
        }

        public void Clear()
        {
            combatPlayer?.Clear();
            combatPlayer = null;
            fightDTO = null;
        }


    }
}
