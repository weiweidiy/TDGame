using System.Collections.Generic;
using UnityEngine;

namespace Game.Common
{

    public abstract class CommonDetailInfoView<T> : MonoBehaviour/* where T : class*/
    {
        public abstract void Refresh(T info);
    }
}


