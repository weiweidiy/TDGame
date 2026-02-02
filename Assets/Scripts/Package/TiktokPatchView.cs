//using TiktokGame;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TiktokGame
{
    public class TiktokPatchView : MonoBehaviour
    {
        [SerializeField] Image imgProgress;
        [SerializeField] TextMeshProUGUI txtProgress;
        public void Refresh(float progress)
        {
            Debug.Log($"TiktokPatchView Refresh called with progress: {progress}");
            // Implement your refresh logic here
            if (imgProgress != null)
            {
                imgProgress.fillAmount = progress;
            }

            if(txtProgress != null)
            {
                txtProgress.text = $"{(int)(progress * 100)}%";
            }
        }
    }

}