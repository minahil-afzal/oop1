using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clocktask.NewFolder1
{
    class clocktype
    {
        public int hours;
        public int minutes;
        public int seconds;

        public clocktype()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        }
        public clocktype(int h)
        {
            hours = h;
        }
        public clocktype(int h, int m)
        {
            hours = h;
            minutes = m;
        }
        public clocktype(int h, int m, int s)
        {
            hours = h;
            minutes = m;
            seconds = s;
        }
        public void incrementsecond()
        {
            seconds++;
        }
        public void incrementminutes()
        {
            minutes++;
        }
        public void incrementhours()
        {
            hours++;
        }
        public void printtime()
        {
            Console.WriteLine(hours + " " + minutes + " " + seconds);
        }
        public bool isequal(int h, int m, int s)
        {
            if (hours == h && minutes == m && seconds == s)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isequal(clocktype temp)
        {
            if (hours == temp.hours && minutes == temp.minutes && seconds == temp.seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


  
