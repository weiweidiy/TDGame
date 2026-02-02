using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.Common;
using JFramework.Game;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Tiktok
{

    public class TiktokCombatView : MonoBehaviour , IAnimationPlayer
    {
        public event Action<TiktokCombatView> onMaskClicked;

        [SerializeField] AdvancedButton btnClose;

        [SerializeField] Transform[] tranSeats;
        [SerializeField] Transform[] leftPoint;
        [SerializeField] Transform[] rightPoint;

        [SerializeField] Transform platformLeft;
        [SerializeField] Transform platformRight;

        private void OnEnable()
        {
            btnClose.onClick.AddListener(OnCloseButtonClicked);
            platformLeft.position = leftPoint[0].position;
            platformRight.position = rightPoint[0].position;
        }


        private void OnDisable()
        {
            btnClose.onClick.RemoveListener(OnCloseButtonClicked);
        }

        private void OnCloseButtonClicked()
        {
            onMaskClicked?.Invoke(this);
        }

        public Transform GetSeat(int index)
        {
            return tranSeats != null && index >= 0 && index < tranSeats.Length ? tranSeats[index] : null;
        }

        public async Task Play(string animName, bool loop = true)
        {
            var tasks = new List<UniTask>();
            tasks.Add(platformLeft.DOMove(leftPoint[1].position, 0.5f).ToUniTask());
            tasks.Add(platformRight.DOMove(rightPoint[1].position, 0.5f).ToUniTask());
            await UniTask.WhenAll(tasks);
        }

        public void Stop()
        {
            
        }

        public void FlipX()
        {
            
        }

        public void SetAnimation(object animationAsset, bool flipX = false)
        {
            
        }
    }
}
