using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] clothesArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> clothes = new Stack<int>(clothesArr);

            int rackCapacity = int.Parse(Console.ReadLine());

            int sum = 0;
            int racks = 1;

            while (clothes.Count != 0)
            {
                int currentCloth = clothes.Peek();

                if (sum + currentCloth <= rackCapacity)
                {
                    sum += currentCloth;
                    clothes.Pop();
                }
                else if (sum + currentCloth > rackCapacity && clothes.Any())
                {
                    sum = 0;
                    racks++;
                }                
            }

            Console.WriteLine(racks);
        }
    }
}
