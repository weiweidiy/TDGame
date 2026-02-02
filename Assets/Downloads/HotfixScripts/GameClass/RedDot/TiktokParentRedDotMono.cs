using Game.Common;
using System.Collections.Generic;
using UnityEngine;

namespace Tiktok
{
    public class TiktokParentRedDotMono : RedDotParentNode
    {
        [SerializeField] List<TiktokRedDotKey> lstInteresting;

        public override List<string> GetInterestingKeys()
        {
            var result = new List<string>();

            foreach (var i in lstInteresting)
            {

                result.Add(i.ToString());
            }

            return result;
        }

        protected override RedDotManager GetRedDotManager()
        {
            return new TiktokRedDotManager();
        }
    }
}