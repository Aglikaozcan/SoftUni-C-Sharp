using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse));

            Queue<int> locks = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse));

            int intelligenceValue = int.Parse(Console.ReadLine());

            int bulletCount = 0;
            int totalBullets = bullets.Count;

            while (bullets.Any() && locks.Any())
            {
                var currentBullet = bullets.Peek();
                var currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                bullets.Pop();
                bulletCount++;

                if (bulletCount == barrelSize)
                {
                    Console.WriteLine("Reloading!");
                    continue;
                }
            }

            if (bullets.Count == 0 && locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else if (locks.Count == 0)
            {
                int finalPay = intelligenceValue - bulletCount * priceBullet;

                Console.WriteLine($"{totalBullets - bulletCount} bullets left. Earned ${finalPay}");
            }
        }
    }
}
