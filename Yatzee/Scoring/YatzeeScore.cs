using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Scoring
{
    internal class YatzeeScore : OfAKindBase
    {
        public override string Name
        {
            get { return "Yatzee!"; }
        }

        public override int MatchCount
        {
            get { return 5; }
        }

        protected override void ComputeScore(Dice dice)
        {
            // Calculate a score.  And we did score then we have 50 points
            base.ComputeScore(dice);

            if (Points > 0)
            {
                // Yatzee
                Points = 50;
            }
        }
    }
}
