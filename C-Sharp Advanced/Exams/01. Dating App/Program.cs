using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> males = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> females = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int matches = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                var currentMale = males.Peek();

                if (currentMale <= 0)
                {
                    males.Pop();
                    continue;
                }

                var currentFemale = females.Dequeue();

                if (currentFemale <= 0)
                {                    
                    continue;
                }

                if (currentMale % 25 == 0)
                {
                    males.Pop();
                    males.Pop();
                    continue;
                }

                if (currentFemale % 25 == 0)
                {
                    females.Dequeue();
                    continue;
                }

                if (currentMale == currentFemale)
                {       
                    males.Pop();
                    matches++;
                }
                else if (currentFemale != currentMale)               
                {
                    males.Pop();
                    currentMale -= 2;
                    males.Push(currentMale);
                }                
            }

            Console.WriteLine($"Matches: {matches}");

            if (males.Count > 0)
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (females.Count > 0)
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
