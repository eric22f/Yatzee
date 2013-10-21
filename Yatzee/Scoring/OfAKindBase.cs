using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Scoring
{
    /// <summary>
    /// Base class for scoring where there is three, four, five, etc. of a kind.
    /// The resulting score will be the highest match
    /// </summary>
    internal abstract class OfAKindBase : ScoringBase
    {
        /// <summary>
        /// The number of matching dice needed
        /// </summary>
        public abstract int MatchCount { get; }

        /// <summary>
        /// Compute the Number of a Kind score
        /// </summary>
        protected override void ComputeScore(Dice dice)
        {
            int count = 0;
            int value = 0;
            for (int i = 0; i < dice.Count; i++)
            {
                if (dice[i] == value)
                {
                    count++;
                    // Check if we found three
                    if (count == MatchCount)
                    {
                        // We have our score
                        Points = value * MatchCount;
                        // reset in-case we find a higher score
                        count = 0;
                    }
                }
                else if (dice[i] > value)
                {
                    // We have a new value to keep track of
                    count = 1;
                    value = dice[i];
                }
            }
        }
    }
}
