using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            double price = 0;

            if (city == "Sofia")
            {
                if (product == "coffee")
                {
                    price = amount * 0.50;
                    Console.WriteLine(price);
                }
                else if (product == "water")
                {
                    price = amount * 0.80;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    price = amount * 1.20;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    price = amount * 1.45;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    price = amount * 1.60;
                    Console.WriteLine(price);
                }
            }
            else if (city == "Plovdiv")
            {
               // 0.40    0.70    1.15    1.30    1.50
                if (product == "coffee")
                {
                    price = amount * 0.40;
                    Console.WriteLine(price);
                }
                else if (product == "water")
                {
                    price = amount * 0.70;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    price = amount * 1.15;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    price = amount * 1.30;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    price = amount * 1.50;
                    Console.WriteLine(price);
                }
            }
            else if (city == "Varna")
            {
               // 0.45    0.70    1.10    1.35    1.55
                if (product == "coffee")
                {
                    price = amount * 0.45;
                    Console.WriteLine(price);
                }
                else if (product == "water")
                {
                    price = amount * 0.70;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    price = amount * 1.10;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    price = amount * 1.35;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    price = amount * 1.55;
                    Console.WriteLine(price);
                }
            }
        }
    }
}
