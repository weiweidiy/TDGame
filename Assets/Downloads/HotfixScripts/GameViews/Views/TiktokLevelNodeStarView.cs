using UnityEngine;

namespace Tiktok
{
    public class TiktokLevelNodeStarView : MonoBehaviour
    {
        [SerializeField] Transform[] tranStars;
        public void UpdateStars(int starCount)
        {
            for(int i = 0; i < tranStars.Length; i++)
            {
                tranStars[i].gameObject.SetActive(i < starCount);
            }
        }

        public int GetActiveStarCount()
        {
            int count = 0;
            for (int i = 0; i < tranStars.Length; i++)
            {
                if (tranStars[i].gameObject.activeSelf)
                {
                    count++;
                }
            }
            return count;
        }

        public void ReceiveNewStar(int starIndex)
        {
            Debug.Log("ReceiveNewStar " + starIndex);
            tranStars[starIndex].parent.GetComponent<Animator>().Play("ReceiveNewStar");
        }
    }
}
