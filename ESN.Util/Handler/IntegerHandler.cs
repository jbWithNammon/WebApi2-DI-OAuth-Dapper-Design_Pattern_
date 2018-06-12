using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Util.Handler
{
   public static class IntegerHandler
    {
        public static bool IsNullOrValue(this double? value, double valueToCheck)
        {
            return (value ?? valueToCheck) == valueToCheck;
        }
        public static bool IsNullOrValue(this int? value, int valueToCheck)
        {
            return (value ?? valueToCheck) == valueToCheck;
        }
        public static bool IsZero(this int value)
        {
            return (value == 0);
        }
    }
}
