using UnityEngine;

namespace Game.Common
{
    public class SingleSpriteView : BaseSingleImageView
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        public override void Refresh(Sprite info)
        {
            spriteRenderer.sprite = info;
        }
    }
}


