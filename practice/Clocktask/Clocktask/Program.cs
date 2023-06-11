using Clocktask.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clocktask
{
    class Program
    {
        static void Main(string[] args)
        {
            // default constructor
            clocktype empty_time = new clocktype();
            Console.Write("empty time: ");
            empty_time.printtime();

            // paramatize constructor with one parameter
            clocktype hour_time = new clocktype(8);
            Console.Write("hour time: ");
            hour_time.printtime();

            // paramatize constructor with two parameter
            clocktype minute_time = new clocktype(8,10);
            Console.Write("minute time: ");
            minute_time.printtime();

            // paramatize constructor with three parameter
            clocktype full_time = new clocktype(8,10,30);
            Console.Write("full time: ");
            full_time.printtime();

            //increments second
            full_time.incrementsecond();
            Console.Write("full time(increment second): ");
            full_time.printtime();

            //increments hours
            full_time.incrementhours();
            Console.Write("full time(increment hour): ");
            full_time.printtime();

            //increments minutes
            full_time.incrementminutes();
            Console.Write("full time(increment minutes): ");
            full_time.printtime();

            // check if equal
            bool flag = full_time.isequal(9, 11, 11);
            Console.WriteLine("flag: " + flag);

            // check if equal with objects
            clocktype cmp = new clocktype(10, 12, 1);
            flag = full_time.isequal(cmp);
            Console.WriteLine("object flag: " + flag);
            Console.ReadKey();

        }
    }
}
