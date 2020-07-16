using System;
using System.Linq;

namespace _04._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Trim()
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            char findSymbol = char.Parse(Console.ReadLine());
            int indexRow = 0;
            int indexCol = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == findSymbol)
                    {
                        indexRow = row;
                        indexCol = col;
                        Console.WriteLine($"({indexRow}, {indexCol})");
                        return;
                    }                    
                }
            }

            if (matrix[indexRow, indexCol] != findSymbol)
            {
                Console.WriteLine($"{findSymbol} does not occur in the matrix");
            }
        }
    }
}
