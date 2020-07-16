using System;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split();

            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            var matrix = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                var currentRow = Console.ReadLine().Split();

                matrix[i] = currentRow;
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                if (!input.Contains("swap") || input.Split().Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int row1 = int.Parse(input.Split()[1]);
                int col1 = int.Parse(input.Split()[2]);
                int row2 = int.Parse(input.Split()[3]);
                int col2 = int.Parse(input.Split()[4]);

                if (row1 < 0 || row1 > rows
                    || col1 < 0 || col1 > cols
                    || row2 < 0 || row2 > rows
                    || col2 < 0 || col2 > cols)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string firstElement = matrix[row1][col1];
                string secondElement = matrix[row2][col2];

                matrix[row2][col2] = firstElement;
                matrix[row1][col1] = secondElement;

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write(matrix[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}