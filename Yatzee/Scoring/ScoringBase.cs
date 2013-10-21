using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Scoring
{
    /// <summary>
    /// Base class used for scoring
    /// </summary>
    internal abstract class ScoringBase : IScore
    {
        /// <summary>
        /// Name of this scoring type
        /// </summary>
        abstract public string Name { get; }

        /// <summary>
        /// Calculated Score
        /// </summary>
        public int Points
        {
            get
            {
                return _points;
            }
            protected set
            {
                _points = value;
            }
        }
        private int _points;

        /// <summary>
        /// Calculate the score from the dice
        /// </summary>
        public void CalculateScore(Dice dice)
        {
            // Reset our score
            Points = 0;

            // Check if our dice are valid
            if (dice == null)
            {
                throw new ArgumentNullException("Valid Dice object expected.");
            }

            // Caluclate our score from these dice
            ComputeScore(dice);
        }

        /// <summary>
        /// Function used to caluclate the score
        /// </summary>
        abstract protected void ComputeScore(Dice dice);

        /// <summary>
        /// Compare two IScore objects
        /// </summary>
        public int CompareTo(object obj)
        {
            if (obj.GetType() is IScore)
            {
                return ((IScore)obj).Points.CompareTo(this.Points);
            }
            throw new InvalidCastException("Unable to compare to a non IScore object.");
        }
    }
}
