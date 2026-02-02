using JFramework.Game;
using Spine.Unity;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Common
{
    public class AnimatorPlayer : MonoBehaviour,  IAnimationPlayer
    {
        [SerializeField] Animator animator;

        public void FlipX()
        {
            throw new System.NotImplementedException();
        }

        public Task Play(string animName, bool loop = true)
        {
            animator.Play(animName);
            return Task.CompletedTask;
        }

        public void SetAnimation(object animationAsset, bool flipX = false)
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            
        }
    }
}
