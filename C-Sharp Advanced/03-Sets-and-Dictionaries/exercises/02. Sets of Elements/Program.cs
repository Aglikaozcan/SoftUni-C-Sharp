using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstSet = lengths[0];
            int secondSet = lengths[1];

            HashSet<int> firstGroup = new HashSet<int>();
            HashSet<int> secondGroup = new HashSet<int>();

            for (int i = 1; i <= firstSet + secondSet; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i >= 0 && i <= firstSet)
                {
                    firstGroup.Add(number);
                }
                else
                {
                    secondGroup.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", firstGroup.Intersect(secondGroup)));
        }
    }
}
