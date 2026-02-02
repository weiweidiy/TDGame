using Game.Common;
using TMPro;
using UnityEngine;
using JFramework;
using System.Collections;

namespace Tiktok
{
    public class BuildingInfoView : CommonDetailInfoView<BuildingInfo>
    {
        [SerializeField] TextMeshProUGUI txtLevel;
        [SerializeField] TextMeshProUGUI txtUpgradeTime;

        private Coroutine countdownCoroutine;
        private long remainTime;

        public override void Refresh(BuildingInfo info)
        {
            txtLevel.text = $"Lv.{info.level}";
            remainTime = info.remainTime;
            txtUpgradeTime.gameObject.SetActive(remainTime > 0);

            if (countdownCoroutine != null)
            {
                StopCoroutine(countdownCoroutine);
            }

            if (remainTime > 0)
            {
                countdownCoroutine = StartCoroutine(UpdateCountdown());
            }
            else
            {
                txtUpgradeTime.text = string.Empty;
            }
        }

        private IEnumerator UpdateCountdown()
        {
            while (remainTime > 0)
            {
                txtUpgradeTime.text = remainTime.ToCountdownString();
                yield return new WaitForSeconds(1f);
                remainTime -= 1;
            }
            txtUpgradeTime.gameObject.SetActive(false);
        }
    }
}


