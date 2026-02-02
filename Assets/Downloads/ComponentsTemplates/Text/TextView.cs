using TMPro;
using UnityEngine;

namespace Game.Common
{
    public class TextView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI txtContent;

        public void SetText(string text)
        {
            if (txtContent == null)
            {
                Debug.LogError("TextMeshPro component is not assigned.");
                return;
            }
            txtContent.text = text;
        }
    }
}

