using System.Collections.Generic;

namespace Game.Share
{
    public class RequestAddSamuraiExp
    {
        public int TargetSamuraiId { get; set; }

        public  List<int> ExpSamuraisIds { get; set; }
    }
}