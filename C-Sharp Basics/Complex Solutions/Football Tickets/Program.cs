using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());

            double money = 0;
            double transport = 0;
            double ticket = 0;
            double remaining = 0;

            if (people >= 50)
            {
                transport = budget * 0.25;
            }
            else if (people >= 25)
            {
                transport = budget * 0.40;
            }
            else if (people >= 10)
            {
                transport = budget * 0.50;
            }
            else if (people >= 5)
            {
                transport = budget * 0.60;
            }
            else if (people < 5)
            {
                transport = budget * 0.75;
            }

            money = budget - transport;
            //Console.WriteLine(money);

            if (category == "normal")
            {
                ticket = 249.99 * people;
            }
            else
            {
                ticket = 499.99 * people;
            }

            //Console.WriteLine(ticket);
            remaining = money - ticket;

            if (remaining >= 0)
            {
                Console.WriteLine($"Yes! You have {remaining:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(remaining):f2} leva.");
            }
        }
    }
}
