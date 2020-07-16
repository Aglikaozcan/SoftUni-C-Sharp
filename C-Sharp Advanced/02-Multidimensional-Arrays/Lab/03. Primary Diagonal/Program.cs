using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int startRow = 0;
            int startCol = 0;
            int sum = 0;

            while (true)
            {
                if (startRow >= n || startCol >= n)
                {
                    break;
                }

                sum += matrix[startRow, startCol];
                startRow++;
                startCol++;
            }

            Console.WriteLine(sum);
        }
    }
}
