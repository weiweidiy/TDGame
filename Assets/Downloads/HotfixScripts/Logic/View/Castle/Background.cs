using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Background : MonoBehaviour
    {
        [SerializeField] SpriteRenderer background;

        public void SetBackground(Sprite sp)
        {
            background.sprite = sp;
        }
    }

}