using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copyconstructor
{
    class Program
    {
        class student
        {
            public student()
            {
                Console.WriteLine("defsult constructor");
            }
            public student(student s)

            {
                name = s.name;
                maticmarks = s.maticmarks;
                fscmarks = s.fscmarks;
                ecatmarks = s.ecatmarks;
                aggregate = s.aggregate;
            }
            public string name;
            public float maticmarks;
            public float fscmarks;
            public float ecatmarks;
            public float aggregate;
        }

        static void Main(string[] args)
        {
            student s1 = new student();
            s1.name = "jack";
            student s2 = new student();
            s2.name = "john";
            Console.WriteLine(s1.name);
            Console.WriteLine(s2.name);
            Console.ReadKey();
        }
    }
}
