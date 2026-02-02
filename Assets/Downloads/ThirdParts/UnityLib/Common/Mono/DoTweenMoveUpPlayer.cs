using Cysharp.Threading.Tasks;
using DG.Tweening;
using JFramework.Game;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Common
{
    public class DoTweenMoveUpPlayer : MonoBehaviour, IAnimationPlayer
    {
        [SerializeField] bool playOnEnable;
        [SerializeField] float yDistance = 0.3f;

        private async void OnEnable()
        {
            await Play("", false);
        }

        public void FlipX()
        {
            //throw new System.NotImplementedException();
        }
        public async Task Play(string animName, bool loop = true)
        {
           await transform.DOBlendableLocalMoveBy(new Vector3(0, yDistance, 0), 0.5f).SetLoops(loop ? -1 : 1, LoopType.Restart).SetEase(Ease.InOutSine);
        }

        public void SetAnimation(object animationAsset, bool flipX = false)
        {
            //throw new System.NotImplementedException();
        }
        public void Stop()
        {
            //throw new System.NotImplementedException();
        }
    }
}
