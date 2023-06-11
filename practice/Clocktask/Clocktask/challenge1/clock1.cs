using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock1
{
    class clock
    {
        int hours;
        int seconds;
        int minutes;

        public clocktype(int h, int m, int s)
        {
            hours = h;
            minutes = m;
            seconds = s;
        }
        public int elapsed()
        {
            int time = ((hours * 3600) + (minutes * 60) + (seconds));
            return time;
        }
        public int remaiming()
        {
            int timeinseconds = (24 * 60 * 60);
            return timeinseconds;

        }
    }
}
