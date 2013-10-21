using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Scoring
{
    interface IScore : IComparable
    {
        /// <summary>
        /// Name of the Scoring Rule
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Total points calculated
        /// </summary>
        int Points { get; }

        /// <summary>
        /// Calculate the score for this roll
        /// </summary>
        void CalculateScore(Dice dice);
    }
}
