using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");

                string color = input[0];
                string[] clothes = input[1].Split(',');

                for (int j = 0; j < clothes.Length; j++)
                {
                    string item = clothes[j];

                    if (!wardrobe.ContainsKey(color))
                    {
                        wardrobe[color] = new Dictionary<string, int>();
                    }
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color][item] = 0;
                    }
                    wardrobe[color][item]++;
                }
            }

            string[] neededItem = Console.ReadLine().Split();

            string neededColor = neededItem[0];
            string neededObject = neededItem[1];

            foreach (var colorKvp in wardrobe)
            {
                string color = colorKvp.Key;

                Console.WriteLine($"{color} clothes:");

                foreach (var clothesKvp in colorKvp.Value)
                {
                    string item = clothesKvp.Key;
                    int count = clothesKvp.Value;

                    if (neededColor == color && neededObject == item)
                    {
                        Console.WriteLine($"* {item} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item} - {count}");
                    }                    
                }
            }
        }
    }
}
