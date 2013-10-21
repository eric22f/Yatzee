using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Scoring
{
    /// <summary>
    /// Sum of all dice
    /// </summary>
    internal class Chance : ScoringBase
    {
        public override string Name
        {
            get { return "Chance"; }
        }

        /// <summary>
        /// Add up all of the dice
        /// </summary>
        protected override void ComputeScore(Dice dice)
        {
            dice.ForEach(d => Points += d);
        }
    }
}
