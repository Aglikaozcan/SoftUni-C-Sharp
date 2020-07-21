using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new SortedDictionary<string, Dictionary<string, decimal>>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "Revision")
                {
                    break;
                }

                var productParts = line.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var shop = productParts[0];
                var product = productParts[1];
                var price = decimal.Parse(productParts[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, decimal>();
                }

                shops[shop].Add(product, price);
            }

            foreach (var kvp in shops)
            {
                var shop = kvp.Key;
                var products = kvp.Value;

                Console.WriteLine($"{shop}->");

                foreach (var productKvp in products)
                {
                    Console.WriteLine($"Product: {productKvp.Key}, Price: {productKvp.Value:f1}");
                }
            }
        }
    }
}
