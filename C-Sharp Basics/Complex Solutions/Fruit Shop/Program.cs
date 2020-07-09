using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            double price = 0;

            bool weekend = dayOfWeek == "Saturday" || dayOfWeek == "Sunday";
            bool workday = dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Wednesday" || dayOfWeek == "Thursday" || dayOfWeek == "Friday";

            if (workday)
            {
                //banana	apple	orange	grapefruit	kiwi	pineapple	grapes
                //2.50	1.20	0.85	1.45	2.70	5.50	3.85
                if (fruit == "banana")
                {
                    price = amount * 2.50;
                }
                else if (fruit == "apple")
                {
                    price = amount * 1.20;
                }
                else if (fruit == "orange")
                {
                    price = amount * 0.85;
                }
                else if (fruit == "grapefruit")
                {
                    price = amount * 1.45;
                }
                else if (fruit == "kiwi")
                {
                    price = amount * 2.70;
                }
                else if (fruit == "pineapple")
                {
                    price = amount * 5.50;
                }
                else if (fruit == "grapes")
                {
                    price = amount * 3.85;
                }
                else
                {
                    Console.WriteLine("error");
                }
                Console.WriteLine($"{price:f2}");
            }
            else if (weekend)
            {
                //2.70	1.25	0.90	1.60	3.00	5.60	4.20
                if (fruit == "banana")
                {
                    price = amount * 2.70;
                }
                else if (fruit == "apple")
                {
                    price = amount * 1.25;
                }
                else if (fruit == "orange")
                {
                    price = amount * 0.90;
                }
                else if (fruit == "grapefruit")
                {
                    price = amount * 1.60;
                }
                else if (fruit == "kiwi")
                {
                    price = amount * 3.00;
                }
                else if (fruit == "pineapple")
                {
                    price = amount * 5.60;
                }
                else if (fruit == "grapes")
                {
                    price = amount * 4.20;
                }
                else
                {
                    Console.WriteLine("error");
                }
                Console.WriteLine($"{price:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }

    }
}
