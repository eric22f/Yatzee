using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Scoring
{
    internal class FullHouse : OfAKindBase
    {
        public override string Name
        {
            get { return "Full House"; }
        }

        public override int MatchCount
        {
            get { return 3; }
        }

        /// <summary>
        /// Calculate points for a Full House
        /// </summary>
        protected override void ComputeScore(Dice dice)
        {
            // Check if we have three of a kind
            base.ComputeScore(dice);

            if (Points > 0)
            {
                // Now we need to check if we have the remaining 2 of a kind
                int twoDie = 0;
                int threeDie = Points / 3;
                bool fullHouse = false;
                for (int i = 0; i < dice.Count; i++)
                {
                    // Check if this is not a part of the three of a kind
                    if (dice[i] != threeDie)
                    {
                        // Check if this is the first match for the two of a kind
                        if (twoDie == 0)
                        {
                            twoDie = dice[i];
                        }
                        else if (dice[i] == twoDie)
                        {
                            // We have a full house
                            fullHouse = true;
                            break;
                        }
                        else
                        {
                            // This is not a full house
                            Points = 0;
                            break;
                        }
                    }
                }
                // Check if we matched a full house
                if (fullHouse)
                {
                    Points = 25;
                }
                else
                {
                    Points = 0;
                }
            }
        }
    }
}
