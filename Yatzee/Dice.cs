using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee
{
    /// <summary>
    /// The dice used for the game
    /// </summary>
    internal class Dice : List<int>
    {
        /// <summary>
        /// Roll the dice.  If values are set in reRoll then only those dice will be rolled.
        /// </summary>
        public void Roll(List<int> reRoll = null)
        {
            // Generate Random values for the dice
            Random _rnd = new Random();
            // Check if we do not have any dice to lock
            if (reRoll == null || reRoll.Count == 0)
            {
                // Initialize to 5 dice
                this.Clear();
                for (int i = 0; i < 5; i++)
                {
                    this.Add(_rnd.Next(6) + 1);
                }
            }
            else
            {
                // Only re-roll the dice requested
                for (int i = 0; i < 5; i++)
                {
                    if (reRoll.Contains(i + 1))
                    {
                        this[i] = _rnd.Next(6) + 1;
                    }
                }
            }
            // Sort our Roll
            this.Sort();
        }

    }
}
