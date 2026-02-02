using UnityEngine;

namespace Tiktok
{
    public class TiktokLevelNodeBottomView : MonoBehaviour
    {
        [SerializeField] Transform tranBottom;
        public void ShowBottom()
        {
            tranBottom.gameObject.SetActive(true);
        }

        public void HideBottom()
        {
            tranBottom.gameObject.SetActive(false);
        }
    }
}
