using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Common
{
    public class DoTweenFadePlayer : MonoBehaviour
    {
        [SerializeField] float fadeDuration = 1f;
        [SerializeField] CanvasGroup canvasGroup;
        private async void OnEnable()
        {
            await Play();
        }

        async Task Play()
        {
            canvasGroup.alpha = 0f;
            //淡入0.2f，停留0.3f,淡出0.2f
            await canvasGroup.DOFade(1f, fadeDuration * 0.1f).SetEase(Ease.Linear);
            await UniTask.Delay((int)(fadeDuration * 0.2f * 1000));
            await canvasGroup.DOFade(0f, fadeDuration * 0.2f).SetEase(Ease.Linear);
        }
    }
}
