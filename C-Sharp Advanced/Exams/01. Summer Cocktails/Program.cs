using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _01.SummerCocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> freshness = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> coctails = new Dictionary<string, int>
            {
                { "Mimosa", 150},
                { "Daiquiri", 250},
                { "Sunshine", 300},
                { "Mojito", 400}
            };

            Dictionary<string, int> readyCoctails = new Dictionary<string, int>
            {
                { "Mimosa", 0},
                { "Daiquiri", 0},
                { "Sunshine", 0},
                { "Mojito", 0}
            };

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                var currentIngredient = ingredients.Dequeue();

                if (currentIngredient == 0)
                {
                    continue;
                }

                var currentFreshness = freshness.Pop();

                var total = currentIngredient * currentFreshness;

                if (coctails.ContainsValue(total))
                {
                    var coctailName = coctails.FirstOrDefault(x => x.Value == total).Key;
                    readyCoctails[coctailName]++;
                }
                else if (coctails.ContainsValue(total) == false)
                {
                    currentIngredient += 5;
                    ingredients.Enqueue(currentIngredient);
                }
            }

            if (readyCoctails.All(x => x.Value > 0))
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }            

            foreach (var coctail in readyCoctails.Where(x => x.Value > 0).OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {coctail.Key} --> {coctail.Value}");
            }
        }
    }
}
