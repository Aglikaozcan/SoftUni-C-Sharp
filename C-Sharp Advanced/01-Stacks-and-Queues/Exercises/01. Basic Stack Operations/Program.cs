using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var operations = Console.ReadLine();

            var array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            int elementsToPush = int.Parse(operations.Split()[0]);
            int elementsToPop = int.Parse(operations.Split()[1]);
            int elementToLookFor = int.Parse(operations.Split()[2]);

            for (int i = 0; i < elementsToPush; i++)
            {
                if (i < array.Length)
                {
                    stack.Push(array[i]);
                }
                else
                {
                    break;
                }
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                if (stack.Count != 0)
                {
                    stack.Pop();
                }
                else
                {
                    break;
                }
            }

            if (stack.Contains(elementToLookFor))
            {
                Console.WriteLine("true");
            }
            else if (stack.Any())
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
