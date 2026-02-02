using Adic;
using Adic.Container;
using Game.Common;
using Game.Share;
using GameCommands;
using JFramework;
using JFramework.Game;
using JFramework.Game.View;
using System.Threading.Tasks;
using UnityEngine;
using Event = JFramework.Event;

namespace Tiktok
{
    public class TiktokCombatPlayer : JCombatTurnBasedPlayer<TiktokJCombatUnitData>
    {
        public class EventUnitCast : Event { }
        public class EventUnitHurt : Event { }

        EventManager eventManager;

        [Inject]
        UIManager uiManager;

        [Inject]
        PlayerModel playerModel;

        [Inject]
        public TiktokCombatPlayer(EventManager eventManager,JCombatTurnBasedReportData<TiktokJCombatUnitData> reportData, IJCombatAnimationPlayer animationPlayer, IObjectPool objPool = null) : base(reportData, animationPlayer, objPool)
        {
            this.eventManager = eventManager;

            var player = animationPlayer as TiktokJCombatAnimationPlayer;
            player.onUnitCast += Player_onUnitCast;
            player.onUnitHurt += Player_onUnitHurt;
        }

        /// <summary>
        /// 有战斗单位释放技能
        /// </summary>
        /// <param name="unitData"></param>
        private void Player_onUnitCast(TiktokJCombatAnimationPlayer.UnitData unitData)
        {
            eventManager.Raise<EventUnitCast>(unitData);
        }

        /// <summary>
        /// 受伤事件
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void Player_onUnitHurt(TiktokJCombatAnimationPlayer.UnitData unitData)
        {
            eventManager.Raise<EventUnitHurt>(unitData);
        }

        /// <summary>
        /// 播放战斗结果
        /// </summary>
        /// <returns></returns>
        protected override Task PlayResult()
        {
            var uiProperties = new UIPanelCombatResultProperties
            {
                Result = reportData.winnerTeamUid == playerModel.GetPlayerUid() ? 1 : 0 // 0: Defeat, 1: Victory, 2: Draw
            };

            uiManager.ShowPanel(nameof(UIPanelCombatResult), uiProperties);
            return Task.CompletedTask;
        }

        public void Clear()
        {
            var player = animationPlayer as TiktokJCombatAnimationPlayer;
            player.onUnitCast -= Player_onUnitCast;
            player.onUnitHurt -= Player_onUnitHurt;

            player.Clear();
            Stop();
        }
    }
}

