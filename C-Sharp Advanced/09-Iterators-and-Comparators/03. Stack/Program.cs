using System;
using System.Linq;

namespace P03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            CustomStack<int> stack = new CustomStack<int>();

            while (input != "END")
            {
                string[] splitedInput = input.Split(" ", 2);

                string command = splitedInput[0];

                if (command == "Push")
                {
                    int[] numbers = splitedInput[1]
                        .Split(", ")
                        .Select(int.Parse)
                        .ToArray();

                    stack.Push(numbers);
                }
                else
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var number in stack)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
