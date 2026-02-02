using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Common
{
    /// <summary>
    /// Image类型单一图片视图
    /// </summary>
    public class SingleImageView : BaseSingleImageView
    {
        [SerializeField] private Image image;
        public override void Refresh(Sprite info)
        {
            image.sprite = info;
        }
    }
}


