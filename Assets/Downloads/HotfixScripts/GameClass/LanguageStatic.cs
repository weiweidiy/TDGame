using Adic;
using JFramework;
using TMPro;
using UnityEngine;

namespace Game.Common
{
    public class LanguageStatic : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI txt;
        [SerializeField] string languageBusinessId;

        private void Awake()
        {
            this.Inject();
        }

        [Inject]
        public void Initialize(ILanguageManager languageManager)
        {
            txt.text = languageManager.GetText(languageBusinessId);
        }
    }
}
