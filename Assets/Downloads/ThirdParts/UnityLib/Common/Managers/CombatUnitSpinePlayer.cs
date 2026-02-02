using Adic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using JFramework;
using JFramework.Game;
using Spine;
using Spine.Unity;
using System.Threading.Tasks;
using UnityEngine;


namespace Tiktok
{

    public class CombatUnitSpinePlayer : SpinePlayer
    {
        TaskCompletionSource<bool> tcs;

        protected override void OnDisable()
        {
            base.OnDisable();

            if (tcs != null && !tcs.Task.IsCompleted)
            {
                tcs.SetCanceled();
                tcs = null; // 清理 TaskCompletionSource
            }

            if (tcs != null)
                tcs = null;
        }

        protected override void OnSpineAnimationComplete(TrackEntry trackEntry)
        {
            if (tcs != null && !tcs.Task.IsCompleted && trackEntry.Animation.Name == "attack")//to do:消除这个特殊处理
            {
                tcs.SetResult(true);
                Play("idle", true);
            }
        }

        public override Task Play(string animName, bool loop = true)
        {
            var task = base.Play(animName, loop);
            if (animName == "attack")
            {
                tcs = new TaskCompletionSource<bool>();
                spine.AnimationState.SetAnimation(0, animName, loop);
                return tcs.Task;
            }

            return task;
        }

        public async Task PlayDead()
        {
            spine.AnimationState.ClearTracks();
            //spine.Skeleton.SetColor(new Color(0,0,0,0));
            await FadeOut(0f);
        }

        public async Task FadeOut(float targetAlpha , float duration = 0.5f)
        {
            //Color currentColor = spine.Skeleton.GetColor();

            //await DOTween.To(() => currentColor.a,
            //    alpha =>
            //    {
            //        Color newColor = currentColor;
            //        newColor.a = alpha;
            //        spine.Skeleton.SetColor(newColor);
            //    }, targetAlpha, duration).SetEase(Ease.Linear).ToUniTask()/*.OnComplete(() => { })*/;

            // 获取初始颜色
            Color startColor = spine.Skeleton.GetColor();
            float startAlpha = startColor.a;

            await DOTween.To(() => spine.Skeleton.GetColor().a,
                alpha =>
                {
                    Color newColor = spine.Skeleton.GetColor();
                    newColor.a = alpha;
                    spine.Skeleton.SetColor(newColor);
                }, targetAlpha, duration).SetEase(Ease.Linear).ToUniTask();

            // 最后强制设置一次目标透明度，确保完全透明
            Color finalColor = spine.Skeleton.GetColor();
            finalColor.a = targetAlpha;
            spine.Skeleton.SetColor(finalColor);
        }

    }
}
