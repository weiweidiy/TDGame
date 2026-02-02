using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Common
{
    public class TipsView : MonoBehaviour
    {
        public event Action onComplete;

        [SerializeField] TextMeshProUGUI tipsText;
        [SerializeField] CanvasGroup canvasGroup;

        private Tween fadeTween;

        private void OnEnable()
        {
            // 先终止之前的动画，避免叠加
            fadeTween?.Kill();

            // 初始透明
            canvasGroup.alpha = 0f;

            // 淡入0.5秒 -> 停留1秒 -> 淡出0.5秒
            fadeTween = canvasGroup.DOFade(1f, 0.5f)
                .OnComplete(() =>
                {
                    // 停留1秒后淡出
                    fadeTween = canvasGroup.DOFade(0f, 0.5f).SetDelay(1f);
                    // 淡出完成后清空文本
                    fadeTween.OnComplete(() => {
                        onComplete?.Invoke(); //如果有异常，无法捕获
                        gameObject.SetActive(false);
                    });
                });
        }

        private void OnDisable()
        {
            // 关闭时终止动画
            fadeTween?.Kill();

            tipsText.text = string.Empty;
        }

        public void Show(string message)
        {
            tipsText.text = message;
        }
    }
}