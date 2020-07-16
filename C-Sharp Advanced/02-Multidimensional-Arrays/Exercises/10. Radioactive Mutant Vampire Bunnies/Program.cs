using System;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static char[][] matrix;
        static int playerRow;
        static int playerCol;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            matrix = new char[rows][];

            PopulateMatrix();

            string commands = Console.ReadLine();

            foreach (var command in commands)
            {
                if (command == 'R')
                {
                    Move(0, 1);
                }
                else if (command == 'L')
                {
                    Move(0, -1);
                }
                else if (command == 'U')
                {
                    Move(-1, 0);
                }
                else if (command == 'D')
                {
                    Move(1, 0);
                }

                SpreadBunnies();
            }
        }

        private static void SpreadBunnies()
        {
            throw new NotImplementedException();
        }

        private static void Move(int row, int col)
        {
            if (!IsInside(playerRow + row, playerCol + col))
            {
                Print();
                Console.WriteLine($"won: {playerRow} {playerCol}");
                Environment.Exit(0);
            }           

            if (matrix[playerRow + row][playerCol + col] == 'B')
            {
                Print();
                Console.WriteLine($"dead: {playerRow + row} {playerCol + col}");
                Environment.Exit(0);
            }

            matrix[playerRow][playerCol] = '.';

            playerRow += row;
            playerCol += col;

            matrix[playerRow][playerCol] = 'P';
        }

        private static void Print()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("",row));
            }
        }

        private static void PopulateMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();                    

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.Length & col >= 0 && col < matrix[row].Length;
        }
    }
}
