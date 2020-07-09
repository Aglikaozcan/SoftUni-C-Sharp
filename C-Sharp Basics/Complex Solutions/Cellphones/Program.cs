using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellphones
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            string brand = Console.ReadLine();

            //Gsm4e	Mobifon4e	Telefon4e
            //20.50	50.75	    115
            //1%	2%      	3%

            //От 10 до 20	От 20 до 50	> 50
            //2%	        5%	     7%

            double price = 0;
            double discount = 0;
            double discountNumber = 0;
            double totalPrice = 0;
            double remaining = 0;
            double totalPricePhone = 0;

            if (brand == "Gsm4e")
            {
                price = 20.50;
                discount = 0.01;
            }
            else if (brand == "Mobifon4e")
            {
                price = 50.75;
                discount = 0.02;
            }
            else if (brand == "Telefon4e")
            {
                price = 115;
                discount = 0.03;
            }

            if (number > 50)
            {
                discountNumber = 0.07;
            }
            else if (number > 20 && number <= 50)
            {
                discountNumber = 0.05;
            }
            else if (number > 10 && number <= 20)
            {
                discountNumber = 0.02;
            }

            totalPricePhone = price * number;
            totalPrice = totalPricePhone - totalPricePhone * (discount + discountNumber);
            remaining = budget - totalPrice;

            if (remaining >= 0)
            {
                Console.WriteLine($"The company bought all mobile phones. {remaining:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money for all mobiles. Company needs {Math.Abs(remaining):f2} more leva.");
            }
        }
    }
}
