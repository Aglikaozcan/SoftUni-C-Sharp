using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new Queue<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0)
                {
                    numbers.Enqueue(input[i]);
                }
            }

            var result = numbers.ToList();

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
