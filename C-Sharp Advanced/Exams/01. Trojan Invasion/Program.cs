using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _01.TrojanInvasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            var plates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var currentWave = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                if (plates.Count == 0)
                {                    
                    break;
                }

                currentWave = new Stack<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Add(newPlate);
                }

                while (currentWave.Count > 0 && plates.Count > 0)
                {
                    var currentWarrior = currentWave.Pop();
                    var currentPlate = plates[0];

                    if (currentWarrior > currentPlate)
                    {
                        currentWarrior -= currentPlate;
                        currentWave.Push(currentWarrior);
                        plates.RemoveAt(0);
                    }
                    else if (currentWarrior < currentPlate)
                    {
                        plates[0] -= currentWarrior;
                    }
                    else
                    {
                        plates.RemoveAt(0);
                    }
                }
            }

            if (plates.Count != 0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", currentWave)}");
            }
        }
    }
}