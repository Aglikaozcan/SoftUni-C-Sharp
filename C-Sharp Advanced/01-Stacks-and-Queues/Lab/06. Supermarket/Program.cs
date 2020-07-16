using System.Collections.Generic;
using System;

namespace _06.Supermarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (input == "Paid")
                {
                    foreach (var name in names)
                    {
                        Console.WriteLine(name);
                    }

                    names.Clear();
                }
                else
                {
                    names.Enqueue(input);
                }
            }

            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
