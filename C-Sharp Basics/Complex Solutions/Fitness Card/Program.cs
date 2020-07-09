using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_Card
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double price = 0;

            if (age > 19)
            {
                if (gender == "m")
                {
                    if (sport == "Gym")
                    {
                        price = 42;
                    }
                    else if (sport == "Boxing")
                    {
                        price = 41;
                    }
                    else if (sport == "Yoga")
                    {
                        price = 45;
                    }
                    else if (sport == "Zumba")
                    {
                        price = 34;
                    }
                    else if (sport == "Dances")
                    {
                        price = 51;
                    }
                    else if (sport == "Pilates")
                    {
                        price = 39;
                    }
                }
                else if (gender == "f")
                {
                    if (sport == "Gym")
                    {
                        price = 35;
                    }
                    else if (sport == "Boxing")
                    {
                        price = 37;
                    }
                    else if (sport == "Yoga")
                    {
                        price = 42;
                    }
                    else if (sport == "Zumba")
                    {
                        price = 31;
                    }
                    else if (sport == "Dances")
                    {
                        price = 53;
                    }
                    else if (sport == "Pilates")
                    {
                        price = 37;
                    }
                }
            }
            else if (age <= 19)
            {
                if (gender == "m")
                {
                    if (sport == "Gym")
                    {
                        price = 42 * 0.8;
                    }
                    else if (sport == "Boxing")
                    {
                        price = 41 * 0.8;
                    }
                    else if (sport == "Yoga")
                    {
                        price = 45 * 0.8;
                    }
                    else if (sport == "Zumba")
                    {
                        price = 34 * 0.8;
                    }
                    else if (sport == "Dances")
                    {
                        price = 51 * 0.8;
                    }
                    else if (sport == "Pilates")
                    {
                        price = 39 * 0.8;
                    }
                }
                else if (gender == "f")
                {
                    if (sport == "Gym")
                    {
                        price = 35 * 0.8;
                    }
                    else if (sport == "Boxing")
                    {
                        price = 37 * 0.8;
                    }
                    else if (sport == "Yoga")
                    {
                        price = 42 * 0.8;
                    }
                    else if (sport == "Zumba")
                    {
                        price = 31 * 0.8;
                    }
                    else if (sport == "Dances")
                    {
                        price = 53 * 0.8;
                    }
                    else if (sport == "Pilates")
                    {
                        price = 37 * 0.8;
                    }
                }
            }
            double difference = budget - price;
            if (difference >= 0)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${Math.Abs(difference):f2} more.");
            }

        }
    }
}
