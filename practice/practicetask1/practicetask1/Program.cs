using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicetask1
{
    class student
        {
        public string name;
        public float maticmarks;
        public float fscmarks;
        public float ecatmarks;
        public float aggregate;
        }
    class Program
    {
        static void Main(string[] args)
        {
            student s1 = new student();
            Console.WriteLine(s1.name);
            Console.WriteLine(s1.maticmarks);
            Console.WriteLine(s1.fscmarks);
            Console.WriteLine(s1.ecatmarks);
            Console.WriteLine(s1.aggregate);
            Console.Read();

        }
    }
}
