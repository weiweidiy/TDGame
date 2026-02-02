using System;
using System.Threading.Tasks;

namespace JFramework.Game
{
    public interface IAnimationPlayer
    {
        //event Action<string> onPlayCompleted;

        Task Play(string animName, bool loop = true);

        void Stop();

        void FlipX();

        void SetAnimation(object animationAsset, bool flipX = false);
    }
}
