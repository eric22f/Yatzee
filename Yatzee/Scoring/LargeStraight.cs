using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Scoring
{
    internal class LargeStraight : StraightBase
    {
        public override string Name
        {
            get { return "Large Straight"; }
        }

        public override int Length
        {
            get { return 5; }
        }
    }
}
