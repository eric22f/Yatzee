using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Scoring
{
    /// <summary>
    /// Base class for scoring astraight
    /// </summary>
    internal abstract class StraightBase : ScoringBase
    {
        public abstract int Length { get; }

        protected override void ComputeScore(Dice dice)
        {
            // The the count of the number of dice in a row
            int count = 1;
            int maxCount = 1;
            for (int i = 1; i < dice.Count; i++)
            {
                if (dice[i] == dice[i - 1] + 1)
                {
                    count++;
                    if (count > maxCount)
                    {
                        maxCount = count;
                    }
                }
                else
                {
                    // Reset our Count
                    count = 1;
                }
            }
            // Check if we have a straight
            if (maxCount >= Length)
            {
                // Points are based on the length of the straight
                switch (Length)
                {
                    case 4:
                        Points = 30;
                        break;
                    case 5:
                        Points = 40;
                        break;
                }
            }
        }
    }
}
