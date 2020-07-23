using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.SpaceshipCrafting
{
    public class Program
    {
        static void Main(string[] args)
        {            
            Queue<int> liquidsQueue = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> itemsStack = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<int, string> materials = new Dictionary<int, string>
            {
                {25,  "Glass"},
                {50, "Aluminium"},
                {75, "Lithium"},
                {100, "Carbon fiber"}
            };

            Dictionary<string, int> boughtMaterials = new Dictionary<string, int>
            {
                { "Glass", 0},
                { "Aluminium", 0},
                { "Lithium", 0},
                { "Carbon fiber", 0}
            };

            while (liquidsQueue.Count > 0 && itemsStack.Count > 0)
            {
                int currentLiquid = liquidsQueue.Dequeue();
                int currentItem = itemsStack.Pop();

                int sum = currentLiquid + currentItem;

                if (materials.ContainsKey(sum) == false)
                {
                    currentItem += 3;
                    itemsStack.Push(currentItem);
                }
                else
                {
                    var materialName = materials[sum];

                    boughtMaterials[materialName]++;
                }
            }

            if (boughtMaterials.All(x => x.Value >= 1))
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquidsQueue.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquidsQueue)}");
            }
            else
            {
                Console.WriteLine($"Liquids left: none");
            }

            if (itemsStack.Count > 0)
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", itemsStack)}");
            }
            else
            {
                Console.WriteLine($"Physical items left: none");
            }

            foreach (var kvp in boughtMaterials.Where(x => x.Value > 0).OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}