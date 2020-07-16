using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] ordersArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(ordersArr);

            int biggestOrder = orders.Max();

            Console.WriteLine(biggestOrder);

            while (orders.Count != 0)
            {
                
                if (foodQuantity >= orders.Peek())
                {
                    int currentOrder = orders.Dequeue();

                    foodQuantity -= currentOrder;
                }
                else
                {
                    break;
                }
            }

            if (orders.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(", ", orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
