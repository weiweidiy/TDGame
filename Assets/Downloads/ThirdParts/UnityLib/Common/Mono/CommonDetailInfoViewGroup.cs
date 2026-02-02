using System.Collections.Generic;
using UnityEngine;

namespace Game.Common
{
    public class CommonDetailInfoViewGroup<TView, TArgs> : MonoBehaviour where TView : CommonDetailInfoView<TArgs> where TArgs : class
    {
        [SerializeField] TView[] infoViews;

        public int Count => infoViews.Length;

        public void Refresh(List<TArgs> args)
        {
            if(args == null)
            {
                args = new List<TArgs>();
            }

            for (int i = 0; i < infoViews.Length; i++)
            {
                if (i < args.Count)
                {
                    infoViews[i].gameObject.SetActive(true);
                    infoViews[i].Refresh(args[i]);
                }
                else
                {
                    infoViews[i].gameObject.SetActive(false);
                }
            }
        }
    }
}


