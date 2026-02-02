using UnityEngine;
using UnityEngine.UI;

namespace Game.Common
{
    public class ProgressBarView : CommonDetailInfoView<(int current, int max)>
    {
        [SerializeField] BaseSingleTextView txtProcess;
        [SerializeField] Image imgProcess;

        public override void Refresh((int current, int max) info)
        {    
            float process = (float)info.current / info.max;
            txtProcess.Refresh($"{info.current}/{info.max}");
            imgProcess.fillAmount = process;
        }
    }
}


