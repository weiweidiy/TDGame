using Game.Common;
using System;
using UnityEngine;


namespace JFramework.Game.View
{
    [Serializable]
    public class UIMenuItem<TType> : IUIMenuItem<TType>
    {
        /// <summary>
        /// 编辑器可见
        /// </summary>
        [SerializeField] TType key;
        [SerializeField] AdvancedButton value;

        /// <summary>
        /// 实现接口
        /// </summary>
        public TType Key => key;
        public AdvancedButton Value => value;
    }
}
