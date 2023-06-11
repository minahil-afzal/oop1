using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Class
{
    public class clockType
    {
        public clockType()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        }
        public clockType(int h)
        {
            hours = h;
        }
        public clockType(int h, int m)
        {
            hours = h;
            minutes = m;
        }
        public clockType(int h, int m, int s)
        {
            hours = h;
            minutes = m;
            seconds = s;
        }
        public int elapsedTime()
        {
            int result = (hours * 3600) + (minutes * 60) + (seconds);
            return result;

        }
        public int remainingTime(int eltime)
        {
            int res = 86400 - eltime;
            return res;
        }
        public void difference(int h, int m, int s)
        {
            if (hours > h)
            {
                hours = hours - h;
            }
            else if (h > hours)
            {
                hours = h - hours;
            }
            if (minutes > m)
            {
                minutes = minutes - m;
            }
            else if (m > minutes)
            {
                minutes = m - minutes;
            }
            if (seconds > s)
            {
                seconds = seconds - s;
            }
            else if (s > seconds)
            {
                seconds = s - seconds;
            }
            Console.WriteLine("The time after difference is: ");
            Console.Write("{0} : {1} : {2}", hours, minutes, seconds);
        }

        public void printTime()
        {
            Console.WriteLine("{0} : {1} : {2}", hours, minutes, seconds);
        }
        public bool isEqual(int h, int m, int s)
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
        public bool isEqual(clockType temp)
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
        public int hours;
        public int minutes;
        public int seconds;
    }
}