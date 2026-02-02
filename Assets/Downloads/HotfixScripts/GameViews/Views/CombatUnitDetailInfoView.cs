using Game.Common;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tiktok
{
    public class CombatUnitDetailInfoView : CommonDetailInfoView<CombatUnitDetailInfo>
    {
        [SerializeField] GameObject goBody;
        [SerializeField] TextMeshProUGUI txtName;

        [SerializeField] TextMeshProUGUI txtHp;
        [SerializeField] Image headIcon;
        [SerializeField] Image hpProcess;
        [SerializeField] TextMeshProUGUI txtAttack;
        [SerializeField] TextMeshProUGUI txtDefense;
        [SerializeField] TextMeshProUGUI txtSoldierName;



        public override void Refresh(CombatUnitDetailInfo info)
        {
            if (info == null)
            {
                goBody.SetActive(false);
                return;
            }

            //Debug.Log("CombatUnitDetailInfoView refresh!!!!!");

            goBody.SetActive(true);

            try
            {
                txtName.text = info.name;
                headIcon.sprite = info.headIcon;
                txtHp.text = $"{info.hp}/{info.maxHp}";
                hpProcess.fillAmount = (float)info.hp / info.maxHp;
                txtAttack.text = info.attack.ToString();
                txtDefense.text = info.defence.ToString();
                txtSoldierName.text = info.soldierName;
            }
            catch(Exception e)
            {
                Debug.LogError($"CombatUnitDetailInfoView Refresh error: {e}");
            }

        }
    }
}


