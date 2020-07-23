using System;
using System.Collections.Generic;
using System.Linq;


namespace _02.SeashellTreasure
{
    class Program
    {
        static char[][] matrix;
        static int evilRow;
        static int evilCol;
        static int stolenSeashells;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            matrix = new char[rows][];
            List<char> seashells = new List<char>();

            PopulateMatrix();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Sunset")
                {
                    break;
                }

                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                if (tokens.Length == 3 && IsInside(row, col))
                {
                    if (matrix[row][col] != '-')
                    {
                        seashells.Add(matrix[row][col]);
                        matrix[row][col] = '-';
                    }
                }
                else if (tokens.Length == 4 && IsInside(row, col))
                {
                    string direction = tokens[3];
                    evilRow = row;
                    evilCol = col;

                    if (matrix[row][col] != '-')
                    {
                        stolenSeashells++;
                        matrix[row][col] = '-';
                    }

                    if (direction == "left")
                    {
                        Move(0, -1);
                    }
                    else if (direction == "right")
                    {
                        Move(0, 1);
                    }
                    else if (direction == "up")
                    {
                        Move(-1, 0);
                    }
                    else if (direction == "down")
                    {
                        Move(1, 0);
                    }
                }
            }

            PrintMatrix();
            Console.Write($"Collected seashells: {seashells.Count}");

            if (seashells.Count > 0)
            {
                Console.Write($" -> {string.Join(", ", seashells)}");
            }

            Console.WriteLine();
            Console.WriteLine($"Stolen seashells: {stolenSeashells}");
        }

        private static void Move(int row, int col)
        {
            int count = 0;

            while (IsInside(evilRow + row, evilCol + col) && count < 3)
            {
                evilRow += row;
                evilCol += col;

                if (matrix[evilRow][evilCol] != '-')
                {
                    stolenSeashells++;
                    matrix[evilRow][evilCol] = '-';
                }
                count++;
            }
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row).Trim());
            }
        }

        private static void PopulateMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.Length & col >= 0 && col < matrix[row].Length;
        }
    }
}
