using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock
{
    internal class Time
    {
        public static int GetHours()
        {
            int hours = (int)DateTime.Now.Hour;
            return hours > 12 ? hours - 12 : hours;
        }

        public static int GetMinutes()
        {
            return (int)DateTime.Now.Minute;
        }
    }
}
