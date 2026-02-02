using Cysharp.Threading.Tasks;
using DG.Tweening;
using JFramework.Game;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Common
{

    public class DoTweenUniTaskDelayPlayer : MonoBehaviour, IAnimationPlayer
    {
        [SerializeField] float delay = 1f;
        private async void OnEnable()
        {
            await Play("", false);
        }

        public void FlipX()
        {
        }

        public async Task Play(string animName, bool loop = true)
        {
            await UniTask.Delay((int)(delay * 1000));
        }

        public void SetAnimation(object animationAsset, bool flipX = false)
        {

        }

        public void Stop()
        {

        }
    }
}
