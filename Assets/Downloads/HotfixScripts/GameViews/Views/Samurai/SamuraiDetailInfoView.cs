using Game.Common;
using JFramework.Game.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tiktok
{
    public class SamuraiDetailInfoView : CommonDetailInfoView<SamuraiDetailInfo>
    {
        [SerializeField] GameObject goBody;
        [SerializeField] BaseSingleTextView txtName;
        [SerializeField] BaseSingleTextView txtLevel;
        //[SerializeField] BaseSingleTextView txtHp;
        //[SerializeField] BaseSingleTextView txtExp;

        [SerializeField] BaseSingleTextView txtPower;
        [SerializeField] BaseSingleTextView txtDef;
        [SerializeField] BaseSingleTextView txtInt;

        [SerializeField] BaseSingleTextView txtAttack;
        [SerializeField] BaseSingleTextView txtDefence;
        [SerializeField] BaseSingleTextView txtSpeed;

        [SerializeField] BaseSingleTextView txtSoldierName;


        [SerializeField] ProgressBarView imgHpProcess;
        [SerializeField] ProgressBarView imgExpProcess;

        private void Awake()
        {
            Refresh(null);
        }


        private void OnEnable()
        {
            //Refresh(null);
        }

        public override void Refresh(SamuraiDetailInfo samuraiInfo)
        {
            if (samuraiInfo == null)
            {
                goBody.SetActive(false);
                return;
            }

            goBody.SetActive(true);


            txtName.Refresh(samuraiInfo.name);
            //txtHp.Refresh(samuraiInfo.hp.ToString() + "/" + samuraiInfo.maxHp.ToString());
            txtLevel.Refresh("Lv." + samuraiInfo.level.ToString());

            if (imgHpProcess != null)
                imgHpProcess.Refresh((samuraiInfo.hp, samuraiInfo.maxHp));

            if (imgExpProcess != null)
                imgExpProcess.Refresh((samuraiInfo.exp, samuraiInfo.maxExp));

            //txtPower.text = samuraiInfo.power.ToString();
            txtPower.Refresh(samuraiInfo.power.ToString());
            txtDef.Refresh(samuraiInfo.def.ToString());
            txtInt.Refresh(samuraiInfo.intel.ToString());
            if (txtAttack != null)
                txtAttack.Refresh(samuraiInfo.attack.ToString());
            if (txtDefence != null)
                txtDefence.Refresh(samuraiInfo.defence.ToString());
            if (txtSpeed != null)
                txtSpeed.Refresh(samuraiInfo.speed.ToString());
            txtSoldierName.Refresh(samuraiInfo.soldierName);

        }
    }
}


