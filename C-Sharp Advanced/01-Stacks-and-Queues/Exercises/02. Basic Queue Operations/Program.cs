using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int elementsToAdd = input[0];
            int elementsToRemove = input[1];
            int elementToLookFor = input[2];

            var array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < elementsToAdd; i++)
            {
                if (i < array.Length)
                {
                    queue.Enqueue(array[i]);
                }
                else
                {
                    break;
                }
            }

            for (int i = 0; i < elementsToRemove; i++)
            {
                if (queue.Count != 0)
                {
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (queue.Contains(elementToLookFor))
            {
                Console.WriteLine("true");
            }
            else if (queue.Any())
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
