using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Scoring
{
    /// <summary>
    /// Four of a Kind
    /// </summary>
    internal class FourOfAKind : OfAKindBase
    {
        public override string Name
        {
            get { return "Four of a Kind"; }
        }

        /// <summary>
        /// Four of a Kind
        /// </summary>
        public override int MatchCount
        {
            get { return 4; }
        }
    }
}
