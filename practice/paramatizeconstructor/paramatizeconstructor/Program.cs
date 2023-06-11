using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paramatizeconstructor
{
    class Program
    {
        class student
        {
            public student(string n, float m,float f,float e,float a)

            {
                name = n;
                maticmarks = m;
                fscmarks = f;
                ecatmarks = e;
                aggregate = a;

            }
            public string name;
            public float maticmarks;
            public float fscmarks;
            public float ecatmarks;
            public float aggregate;
        }
        static void Main(string[] args)
        {
            student s1 = new student("jack",1040 ,1020,200,82);
            Console.WriteLine(s1.name);
            Console.WriteLine(s1.maticmarks);
            Console.WriteLine(s1.fscmarks);
            Console.WriteLine(s1.ecatmarks);
            Console.WriteLine(s1.aggregate);
            student s2 = new student("john", 1040, 1020, 200, 82);
            Console.WriteLine(s2.name);
            Console.WriteLine(s2.maticmarks);
            Console.WriteLine(s2.fscmarks);
            Console.WriteLine(s2.ecatmarks);
            Console.WriteLine(s2.aggregate);
            Console.Read();
        }
    }
}
