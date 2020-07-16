using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse));

            Stack<int> bottles = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse));
            
            int wastedWater = 0;

            while (cups.Any() && bottles.Any())
            {
                var currentCup = cups.Peek();
                var currentBottle = bottles.Peek();

                if (currentBottle >= currentCup)
                {
                    wastedWater += currentBottle - currentCup;
                    cups.Dequeue();
                }
                else 
                {
                    currentCup -= currentBottle;
                }

                bottles.Pop();
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
