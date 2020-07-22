using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var materials = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var magicValues = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<int, string> presents = new Dictionary<int, string>
            {
                {150 ,"Doll" },
                {250, "Wooden train"},
                {300, "Teddy bear"},
                {400, "Bicycle"}
            };

            Dictionary<string, int> toys = new Dictionary<string, int>
            {
                {"Doll", 0 },
                {"Wooden train", 0},
                {"Teddy bear", 0 },
                {"Bicycle", 0 }
            };

            while (materials.Count > 0 && magicValues.Count > 0)
            {
                var currentMaterial = materials.Peek();
                var currentMagic = magicValues.Peek();

                if (currentMaterial == 0)
                {
                    materials.Pop();
                    continue;
                }

                if (currentMagic == 0)
                {
                    magicValues.Dequeue();
                    continue;
                }

                int totalMagicLevel = currentMagic * currentMaterial;

                if (presents.ContainsKey(totalMagicLevel))
                {
                    var toyName = presents[totalMagicLevel];
                    toys[toyName]++;

                    materials.Pop();
                    magicValues.Dequeue();
                }
                else if (totalMagicLevel < 0)
                {
                    var sum = currentMaterial + currentMagic;
                    
                    materials.Pop();
                    magicValues.Dequeue();

                    materials.Push(sum);
                }
                else if (!presents.ContainsKey(totalMagicLevel) && totalMagicLevel >= 0)
                {                   
                    currentMaterial += 15;

                    materials.Pop();
                    magicValues.Dequeue();

                    materials.Push(currentMaterial);
                }
            }

            if ((toys["Doll"] >= 1 && toys["Wooden train"] >= 1) ||
                (toys["Teddy bear"] >= 1 && toys["Bicycle"] >= 1))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }

            if (magicValues.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magicValues)}");
            }

            foreach (var toy in toys.Where(x => x.Value > 0).OrderBy(x => x.Key))
            {
                Console.WriteLine($"{toy.Key}: {toy.Value}");
            }
        }
    }
}
