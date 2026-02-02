using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Common
{
    public struct ProgressData
    {
        public int Current;
        public int Max;
    }

    public class SingleImageProgressView : CommonDetailInfoView<ProgressData>
    {
        [SerializeField] private Image image;
        [SerializeField] private BaseSingleTextView uiText;

        public override void Refresh(ProgressData data)
        {
            image.fillAmount = data.Current / (float)data.Max;
            uiText.Refresh($"{data.Current}/{data.Max}");
        }
    }
}


