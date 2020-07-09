using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluminium_dograma
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string delivery = Console.ReadLine();

            double price = 0;
            double priceDelivery = 0;

            if (number < 10)
            {
                Console.WriteLine("Invalid order");
            }
            else
            {
                if (type == "90X130")
                {
                    price = 110;
                    if (number > 60)
                    {
                        price *= 0.92;
                    }
                    else if (number > 30)
                    {
                        price *= 0.95;
                    }
                }
                else if (type == "100X150")
                {
                    price = 140;
                    if (number > 80)
                    {
                        price *= 0.90;
                    }
                    else if (number > 40)
                    {
                        price *= 0.94;
                    }
                }
                else if (type == "130X180")
                {
                    price = 190;
                    if (number > 50)
                    {
                        price *= 0.88;
                    }
                    else if (number > 20)
                    {
                        price *= 0.93;
                    }
                }
                else if (type == "200X300")
                {
                    price = 250;
                    if (number > 50)
                    {
                        price *= 0.86;
                    }
                    else if (number > 25)
                    {
                        price *= 0.91;
                    }
                }

                if (delivery == "With delivery")
                {
                    priceDelivery = 60 + (price * number);
                }
                else
                {
                    priceDelivery = price * number;
                }
                
                if (number > 99)
                {
                    priceDelivery *= 0.96;
                }

                Console.WriteLine($"{priceDelivery:f2} BGN");
            }
        }
    }
}
