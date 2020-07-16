using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine();

                if (input == "2" && stack.Any())
                {
                    stack.Pop();
                }
                else if (input == "3" && stack.Any())
                {
                    Console.WriteLine(stack.Max());
                }
                else if (input == "4" && stack.Any())
                {
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    int element = int.Parse(input.Split()[1]);

                    stack.Push(element);
                }
            }
                
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
