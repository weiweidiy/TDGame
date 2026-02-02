using JFramework.Game;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Tiktok
{
    public class CombatMultiUnitSpinePlayer : MonoBehaviour, IAnimationPlayer
    {
        [SerializeField] CombatUnitSpinePlayer[] spinePlayers;

        public void FlipX()
        {
            foreach (var spine in spinePlayers)
            {
                spine.FlipX();
            }
        }

        public Task PlayHurt(float percent)
        {
            //percent 是0~1的浮点数，每少0.2，spinePlayers中按顺序播放死亡动画PlayDead
            int deadCount = Mathf.Max(0, spinePlayers.Length - Mathf.FloorToInt((percent + 0.2f) / 0.2f));
            if(percent == 0f)
                deadCount = spinePlayers.Length; // 如果百分比为0，全部播放死亡动画


            var tasks = new List<Task>();
            for (int i = 0; i < deadCount; i++)
            {
                tasks.Add(spinePlayers[i].PlayDead());
            }
            return Task.CompletedTask;
        }

        public Task Play(string animName, bool loop = true)
        {
            var tasks = new List<Task>();
            foreach (var spine in spinePlayers)
            {
                tasks.Add(spine.Play(animName, loop));
            }

            return Task.WhenAll(tasks);
        }

        public void SetAnimation(object animationAssets, bool flipX = false)
        {
            foreach (var spine in spinePlayers)
            {
                spine.SetAnimation(animationAssets, flipX);
            }
        }

        public void Stop()
        {
            foreach (var spine in spinePlayers)
            {
                spine.Stop();
            }
        }
    }
}
