using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rangeArg = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int start = rangeArg[0];
            int end = rangeArg[1];

            string typeNumbers = Console.ReadLine();

            List<int> numbers = new List<int>();

            Predicate<int> filter = x => typeNumbers == "odd" ? x % 2 != 0 : x % 2 == 0;
            // Func<int, bool> filterFunc = x => typeNumbers == "odd" ? x % 2 != 0 : x % 2 == 0; //може и така да се зададе

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            Console.WriteLine(string.Join(" ", numbers.Where(x => filter(x)))); //когато имаме предикат, функцията трябва да се задава така

            // Console.WriteLine(string.Join(" ", numbers.Where(filter))); 
        }
    }
}
