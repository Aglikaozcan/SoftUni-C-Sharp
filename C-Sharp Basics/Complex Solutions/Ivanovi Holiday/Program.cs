using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivanovi_Holiday
{
    class Program
    {
        static void Main(string[] args)
        {
            int nights = int.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string transport = Console.ReadLine();

            double priceAdults = 0;
            double priceKids = 0;
            double ticketAdults = 0;
            double ticketsKids = 0;
            double expenseDestination = 0;
            double expenseTransport = 0;
            double total = 0;
            double priceDog = 0;

            if (destination == "Miami")
            {
                if (nights <= 10)
                {
                    priceAdults = 24.99;
                    priceKids = 14.99;
                }
                else if (nights <= 15)
                {
                    priceAdults = 22.99;
                    priceKids = 11.99;
                }
                else if (nights > 15)
                {
                    priceAdults = 20.00;
                    priceKids = 10.00;
                }
            }
            else if (destination == "Canary Islands")
            {
                if (nights <= 10)
                {
                    priceAdults = 32.50;
                    priceKids = 28.50;
                }
                else if (nights <= 15)
                {
                    priceAdults = 30.50;
                    priceKids = 25.60;
                }
                else if (nights > 15)
                {
                    priceAdults = 28.00;
                    priceKids = 22.00;
                }
            }
            else if (destination == "Philippines")
            {
                if (nights <= 10)
                {
                    priceAdults = 42.99;
                    priceKids = 39.99;
                }
                else if (nights <= 15)
                {
                    priceAdults = 41.00;
                    priceKids = 36.00;
                }
                else if (nights > 15)
                {
                    priceAdults = 38.50;
                    priceKids = 32.40;
                }
            }

            if (transport == "train")
            {
                ticketAdults = 22.30;
                ticketsKids = 12.50;
            }
            else if (transport == "bus")
            {
                ticketAdults = 45.00;
                ticketsKids = 37.00;
            }
            else
            {
                ticketAdults = 90.00;
                ticketsKids = 68.50;
            }

            expenseDestination = nights * ((priceAdults * 2) + (priceKids * 3));
            priceDog = expenseDestination + (expenseDestination * 0.25);
            expenseTransport = (2 * ticketAdults) + (3 * ticketsKids);
            total = priceDog + expenseTransport;

            Console.WriteLine($"{total:f3}");
        }
    }
}
