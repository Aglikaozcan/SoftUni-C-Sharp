using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int primarySum = 0;
            int secondarySum = 0;

            for (int i = 0; i < n; i++)
            {
                primarySum += matrix[i, i];
            }

            int startRow = n - 1;
            int startCol = 0;

            while (true)
            {
                if (startRow < 0 || startCol > n)
                {
                    break;
                }

                secondarySum += matrix[startRow, startCol];
                startRow--;
                startCol++;
            }

            int difference = Math.Abs(primarySum - secondarySum);

            Console.WriteLine(difference);
        }
    }
}
