using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accomodations
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double priceStudio = 0;
            double priceApartment = 0;
            
            bool weak = month == "May" || month == "October";
            bool peak = month == "July" || month == "August";
            bool mid = month == "June" || month == "September";

            if (weak)
            {
                priceStudio = 50;
                priceApartment = 65;

                if (nights > 14)
                {
                    priceApartment *= 0.90;
                    priceStudio *= 0.70;
                }
                else if (nights > 7)
                {
                    priceStudio *= 0.95;
                }
            }
            else if (mid)
            {
                priceStudio = 75.20;
                priceApartment = 68.70;

                if (nights > 14)
                {
                    priceStudio *= 0.80;
                    priceApartment *= 0.90;
                }
            }
            else if (peak)
            {
                priceStudio = 76;
                priceApartment = 77;

                if (nights > 14)
                {
                    priceApartment *= 0.90;
                }
            }

            double totalStudio = priceStudio * nights;
            double totalApartment = priceApartment * nights;

            Console.WriteLine($"Apartment: {totalApartment:f2} lv.");
            Console.WriteLine($"Studio: {totalStudio:f2} lv.");

        }
    }
}
