using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int count = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                if (input == "green")
                {
                    int carsToPass = Math.Min(number, cars.Count);

                    for (int i = 0; i < carsToPass; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        count++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
