using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] leftSocksInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] rightSocksInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> leftSocks = new Stack<int>(leftSocksInput);
            Queue<int> rightSocks = new Queue<int>(rightSocksInput);

            List<int> sets = new List<int>();

            while (leftSocks.Any() && rightSocks.Any())
            {
                int leftSock = leftSocks.Peek(); //първо винаги само поглеждаме какво идва
                int rightSock = rightSocks.Peek();

                if (leftSock > rightSock)
                {
                    int setValue = leftSock + rightSock;
                    sets.Add(setValue);

                    leftSocks.Pop(); // щом сме направили комплект, трябва да ги премахнем
                    rightSocks.Dequeue();
                }
                else if (rightSock > leftSock)
                {
                    leftSocks.Pop();
                }
                else
                {
                    rightSocks.Dequeue();
                    int leftsSockIncrement = leftSocks.Pop() + 1; // така се увеличава стойността - вади се елементът, довабя се стойност и се вкарва обратно
                    leftSocks.Push(leftsSockIncrement);
                }
            }

            Console.WriteLine(sets.Max()); //вада директно най-голямата стойност в списъка
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
