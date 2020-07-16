using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            var matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var currentRow = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int rowIndex = 0;
            int colIndex = 0;
            int sum = int.MinValue;

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    var currentSum = matrix[i, j]
                        + matrix[i + 1, j]
                        + matrix[i, j + 1]
                        + matrix[i + 1, j + 1];

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        rowIndex = i;
                        colIndex = j;
                    }
                }
            }

            Console.WriteLine($"{matrix[rowIndex, colIndex]} {matrix[rowIndex, colIndex + 1]}");
            Console.WriteLine($"{matrix[rowIndex + 1, colIndex]} {matrix[rowIndex + 1, colIndex + 1]}");
            Console.WriteLine(sum);
        }
    }
}
