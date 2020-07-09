using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());
            string arena = Console.ReadLine();
            string day = Console.ReadLine();
            string condition = Console.ReadLine();

            double discount = 0;
            double price = 0;
            double priceWithDiscount = 0;
            double priceOneItem = 0;
            double itemsBought = 0;
            double pointsLeft = 0;


            if (arena == "Nagrand" && (day == "Monday" || day == "Wednesday"))
            {
                discount = 0.95;
            }
            else if (arena == "Gurubashi" && (day == "Tuesday" || day == "Thursday"))
            {
                discount = 0.90;
            }
            else if (arena == "Dire Maul" && (day == "Friday" || day == "Saturday"))
            {
                discount = 0.93;
            }

            if (condition == "Poor")
            {
                price = 7000;
            }
            else if (condition == "Normal")
            {
                price = 14000;
            }
            else if (condition == "Legendary")
            {
                price = 21000;
            }

            priceWithDiscount = price * discount;
            priceOneItem = priceWithDiscount / 5;
            itemsBought = Math.Floor(points / priceOneItem);

            if (itemsBought > 5)
            {
                itemsBought = 5;
            }

            pointsLeft = points - (priceOneItem * itemsBought);

            Console.WriteLine($"Items bought: {itemsBought}");
            Console.WriteLine($"Arena points left: {pointsLeft}");

            if (itemsBought == 5)
            {
                Console.WriteLine("Success!");
            }
            else if (itemsBought < 5)
            {
                Console.WriteLine("Failure!");
            }
        }
    }
}
