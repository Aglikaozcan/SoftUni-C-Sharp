using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            double dolar = double.Parse(Console.ReadLine());
           
            double leva = dolar * 1.79549;
            Console.WriteLine("BGN = {0}", Math.Round(leva, 2));
        }
    }
}
