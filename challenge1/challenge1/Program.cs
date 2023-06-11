using lab_3.Class;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {

            clockType empty_time = new clockType();
            Console.Write("Empty time: ");
            empty_time.printTime();

            clockType hour_time = new clockType(8);
            Console.Write("Hour time: ");
            hour_time.printTime();

            clockType minute_time = new clockType(8, 10);
            Console.Write("Minute time: ");
            minute_time.printTime();

            clockType full_time = new clockType(8, 10, 10);
            Console.Write("Full time: ");
            full_time.printTime();

            int eltime = full_time.elapsedTime();
            Console.WriteLine("Elapsed Time: " + eltime);

            int remtime = full_time.remainingTime(eltime);
            Console.WriteLine("Remaining Time: " + remtime);

            full_time.difference(20, 30, 17);
            Console.ReadKey();
        }
    }
}