using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrology {
    static public class MetrologyRound {
        public static double GetRounded(double number, uint countMainChars) {
            int placeInNum = (int)Math.Floor(Math.Log10(Math.Abs(number))) + 1;
            int decimals = (int)countMainChars - placeInNum;
            if (decimals < 0) {
                decimals = 0;
            }
            return Math.Round(number, decimals);
        }
    }
}
