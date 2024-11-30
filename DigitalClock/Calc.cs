using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock
{
    internal class Calc
    {
        /*
        x = radius
        y = from center

        2 * sqrt(x^2 - y^2)
         */
        public static double Width(int height, int lineNumber)
        {
            int radius = height/2;
            int point = lineNumber;
            return 2 * Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(point, 2));
        }
    }
}
