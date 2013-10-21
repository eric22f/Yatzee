using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee
{
    /// <summary>
    /// helper Functions
    /// </summary>
    internal class helpers
    {
        /// <summary>
        /// Convert a small integer into a string
        /// </summary>
        public static string IntToString(int value)
        {
            switch (value)
            {
                case 0: return "Zero";
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                default: return value.ToString();
            }
        }

    }
}
