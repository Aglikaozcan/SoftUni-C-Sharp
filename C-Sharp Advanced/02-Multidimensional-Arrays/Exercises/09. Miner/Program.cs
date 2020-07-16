using System;
using System.Linq;

namespace _09.Miner
{
    class Program
    {
        static char[][] field;
        static int minerRow;
        static int minerCol;
        static int coals;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine().Split();

            field = new char[rows][];

            PopulateMatrix();              

            foreach (var currentDirection in commands)
            {
                switch (currentDirection)
                {
                    case "left":
                        Move(0, -1);
                        break;
                    case "right":
                        Move(0, 1);
                        break;
                    case "up":
                        Move(-1, 0);
                        break;
                    case "down":
                        Move(1, 0);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"{coals} coals left. ({minerRow}, {minerCol})");    
        }

        private static void Move(int row, int col)
        {
            if (IsInside(minerRow + row, minerCol + col))
            {
                minerRow += row;
                minerCol += col;

                if (field[minerRow][minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    Environment.Exit(0); //a trick!
                }

                if (field[minerRow][minerCol] == 'c')
                {
                    coals--;
                    field[minerRow][minerCol] = '*';

                    if (coals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                        Environment.Exit(0);
                    }
                }
            }
        }

        private static void PopulateMatrix()
        {
            for (int i = 0; i < field.Length; i++)
            {
                field[i] = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 'c')
                    {
                        coals++;
                    }

                    if (field[i][j] == 's')
                    {
                        minerRow = i;
                        minerCol = j;
                    }
                }
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < field.Length & col >= 0 && col < field[row].Length;
        }
    }
}