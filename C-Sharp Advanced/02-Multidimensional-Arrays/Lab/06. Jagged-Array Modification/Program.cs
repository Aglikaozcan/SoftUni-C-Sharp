using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] arr = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                arr[i] = currentRow;
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var commandArgs = input.Split();

                var command = commandArgs[0];
                var commandRow = int.Parse(commandArgs[1]);
                var commandCol = int.Parse(commandArgs[2]);
                var value = int.Parse(commandArgs[3]);

                if (commandRow < 0 || commandRow >= arr.Length || commandCol < 0 || commandCol >= arr[commandRow].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (command == "Add")
                {
                    arr[commandRow][commandCol] += value;
                }
                else if (command == "Subtract")
                {
                    arr[commandRow][commandCol] -= value;
                }
            }

            foreach (var row in arr)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
