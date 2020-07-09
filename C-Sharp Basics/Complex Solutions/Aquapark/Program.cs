using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapark
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine().ToLower();
            int hours = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            string day = Console.ReadLine().ToLower();

            bool isEarly = month == "march" || month == "april" || month == "may";
            bool isLate = month == "june" || month == "july" || month == "august";

            double price = 0;
            double discount = 1;
            double discountHours = 1;
            double totalPrice = 0;
            double priceWithDiscount = 0;
            double extraDiscount = 0;

            if (isEarly)
            {
                if (day == "day")
                {
                    price = 10.50;
                }
                else
                {
                    price = 8.40;
                }
            }
            else if (isLate)
            {
                if (day == "day")
                {
                    price = 12.60;
                }
                else
                {
                    price = 10.20;
                }
            }

            if (people >= 4)
            {
                discount = 0.90;
            }
            
            if (hours >= 5)
            {
                discountHours = 0.50;
            }

            priceWithDiscount = price * discount;
            extraDiscount = priceWithDiscount * discountHours;
            totalPrice = extraDiscount * people * hours;

            Console.WriteLine($"Price per person for one hour: {extraDiscount:f2}");
            Console.WriteLine($"Total cost of the visit: {totalPrice:f2}");
        }
    }
}
