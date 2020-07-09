using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double price = 0;

            if (budget <= 100)
            {
                Console.WriteLine("Somewhere in Bulgaria");
                if (season == "summer")
                {
                    price = budget * 0.3;
                    Console.WriteLine($"Camp - {price:f2}");
                }
                else
                {
                    price = budget * 0.7;
                    Console.WriteLine($"Hotel - {price:f2}");
                }
                
            }
            else if (budget <= 1000)
            {
                Console.WriteLine("Somewhere in Balkans");
                if (season == "summer")
                {
                    price = budget * 0.4;
                    Console.WriteLine($"Camp - {price:f2}");
                }
                else
                {
                    price = budget * 0.8;
                    Console.WriteLine($"Hotel - {price:f2}");
                }
            }
            else
            {
                Console.WriteLine("Somewhere in Europe");
                price = budget * 0.9;
                Console.WriteLine($"Hotel - {price:f2}");
            }
        }
    }
}
