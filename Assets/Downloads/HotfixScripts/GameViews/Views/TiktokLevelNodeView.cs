using Game.Common;
using JFramework.Game;
using System;
using UnityEngine;

namespace Tiktok
{
    public class TiktokLevelNodeView : MonoBehaviour
    {
        public event Action<TiktokLevelNodeView> onClicked;
        IAnimationPlayer animPlayer;

        [SerializeField] ClickDetector clickDetector;

        private void Awake()
        {
            animPlayer = GetComponent<IAnimationPlayer>();
        }

        void OnEnable()
        {

            clickDetector.onClicked += ClickDetector_onClicked;
        }

        void OnDisable()
        {
            clickDetector.onClicked -= ClickDetector_onClicked;
        }


        private void ClickDetector_onClicked(object target)
        {
            onClicked?.Invoke(this);
        }

        public void PlayIdle()
        {
            animPlayer.Play("idle");
        }

        public void PlayDead()
        {
            animPlayer.Play("idle");
        }
    }
}
