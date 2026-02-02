using TMPro;
using UnityEngine;

namespace Game.Common
{
    public class SingleTextMeshProTextView : BaseSingleTextView
    {
        [SerializeField] private TextMeshProUGUI uiText;
        public override void Refresh(string info)
        {
            uiText.text = info;
        }
    }
}


