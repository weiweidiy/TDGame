using Adic;
using JFramework;
using JFramework.Game;
using Spine;
using Spine.Unity;
using System.Threading.Tasks;
using UnityEngine;

namespace Tiktok
{
    public abstract class SpinePlayer : MonoBehaviour, IAnimationPlayer
    {
        [SerializeField] protected SkeletonAnimation spine;
        [Inject] protected IAssetsLoader assetsLoader;
        private void Awake()
        {
            this.Inject();
        }

        protected virtual void OnDisable()
        {
            // 反注册事件，防止内存泄漏
            if (spine != null && spine.AnimationState != null)
            {
                spine.AnimationState.Complete -= OnSpineAnimationComplete;
            }

            if (spine.AnimationState == null)
                Debug.LogError("spine is null:" + name);
            // 清除 Spine 动画状态
            spine.AnimationState.ClearTracks();
        }

        public virtual Task Play(string animName, bool loop = true)
        {
            spine.AnimationState.SetAnimation(0, animName, loop);
            return Task.CompletedTask;
        }
        public virtual void FlipX()
        {
            spine.skeleton.ScaleX = -spine.skeleton.ScaleX;
        }
        public virtual void Stop() { }

        /// <summary>
        /// 设置骨骼文件和动画
        /// </summary>
        /// <param name="path"></param>
        /// <param name="flipX"></param>
        public void SetAnimation(object animationAsset, bool flipX = false)
        {
            var asset = animationAsset as SkeletonDataAsset; //  await assetsLoader.LoadAssetAsync<SkeletonDataAsset>(path);

            spine.skeletonDataAsset = asset;
            spine.Initialize(true);
            if (flipX) FlipX();
            if (spine != null && spine.AnimationState != null)
            {
                spine.AnimationState.Complete += OnSpineAnimationComplete;
            }
        }

        protected abstract void OnSpineAnimationComplete(TrackEntry trackEntry);
    }
}
