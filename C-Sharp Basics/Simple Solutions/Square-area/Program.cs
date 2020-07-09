using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square_area
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            int Square_area = a * a;
            Console.Write("Square area = ");
            Console.WriteLine(Square_area);
        }
    }
}
