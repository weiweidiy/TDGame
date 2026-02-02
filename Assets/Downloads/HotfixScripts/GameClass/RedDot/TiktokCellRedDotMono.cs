using Game.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tiktok
{
    //[DefaultExecutionOrder(10000)]
    public class TiktokCellRedDotMono : RedDotCellNode
    {
        [SerializeField] List<TiktokRedDotKey> lstInteresting;

        public override List<string> GetInterestingKeys()
        {
            var result = new List<string>();

            foreach(var i in lstInteresting)
            {
                result.Add(i.ToString());
            }

            return result;
        }

        protected override RedDotManager GetRedDotManager()
        {
            return new TiktokRedDotManager();
        }

        public void AddInteresting(TiktokRedDotKey key)
        {
            AddInteresting(key.ToString());
        }

    }
}