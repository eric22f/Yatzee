using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Scoring
{
    /// <summary>
    /// Match three of a kind
    /// </summary>
    class ThreeOfAKind : OfAKindBase
    {
        public override string Name
        {
            get { return "Three of a Kind"; }
        }

        /// <summary>
        /// Three of a kind
        /// </summary>
        public override int MatchCount
        {
            get { return 3; }
        }

    }
}
