using System;
using System.Collections.Generic;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            var input = Console.ReadLine();

            foreach (var symbol in input)
            {
                stack.Push(symbol);
            }

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
