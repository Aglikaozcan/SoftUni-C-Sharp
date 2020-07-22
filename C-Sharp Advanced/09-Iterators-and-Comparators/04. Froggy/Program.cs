using System;
using System.Linq;

namespace P04.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] stoneValues = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(stoneValues);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
