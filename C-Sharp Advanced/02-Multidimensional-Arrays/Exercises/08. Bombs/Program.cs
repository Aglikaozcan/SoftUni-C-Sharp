using System;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            var matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            var bombs = Console.ReadLine().Split();

            for (int i = 0; i < bombs.Length; i++)
            {
                var bombArgs = bombs[i].Split(",");
                int bombRow = int.Parse(bombArgs[0]);
                int bombCol = int.Parse(bombArgs[1]);

                int bombDamage = matrix[bombRow][bombCol];

                for (int row = bombRow - 1; row <= bombRow + 1; row++)
                {
                    if (row >= 0 && row < matrix.Length)
                    {
                        for (int col = bombCol - 1; col <= bombCol + 1; col++)
                        {
                            if (col >= 0 && col < matrix[row].Length)
                            {
                                if (matrix[row][col] > 0)
                                {
                                    matrix[row][col] -= bombDamage;
                                }
                            }
                        }
                    }                    
                }
            }

            int aliveCells = 0;
            int sum = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[i][j] > 0)
                    {
                        aliveCells++;
                        sum += matrix[i][j];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
