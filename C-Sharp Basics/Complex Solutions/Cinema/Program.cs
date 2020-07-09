using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine().ToLower();
            int row = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());

            double price = 0;

            if (projection == "premiere")
            {
                price = 12.00;
            }
            else if (projection == "normal")
            {
                price = 7.50;
            }
            else if (projection == "discount")
            {
                price = 5.00;
            }
            double income = row * column * price;
            Console.WriteLine($"{income:f2}");
        }
    }
}
