using Game.Common;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tiktok
{
    public class ResourceDetailInfoView : CommonDetailInfoView<ResourceDetailInfo>
    {
        [SerializeField] Image imgIcon;
        [SerializeField] TextMeshProUGUI txtCount;

        public override void Refresh(ResourceDetailInfo info)
        {
            if(info.icon != null)
                imgIcon.sprite = info.icon;

            txtCount.text = info.count.ToString();
        }
    }
}


