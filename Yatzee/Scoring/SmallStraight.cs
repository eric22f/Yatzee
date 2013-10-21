using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Scoring
{
    internal class SmallStraight : StraightBase
    {
        public override string Name
        {
            get { return "Small Straight"; }
        }

        public override int Length
        {
            get { return 4; }
        }
    }
}
