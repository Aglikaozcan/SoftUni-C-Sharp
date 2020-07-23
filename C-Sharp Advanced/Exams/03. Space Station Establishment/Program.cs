using System;
using System.Linq;

namespace P03.SpaceStationEstablishment
{
    class Program
    {
        static char[][] matrix;
        static int playerRow;
        static int playerCol;
        static int starPower;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            matrix = new char[n][];

            PopulateMatrix();
                        
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "right")
                {
                    Move(0, 1);
                }
                else if (command == "left")
                {
                    Move(0, -1);
                }
                else if (command == "up")
                {
                    Move(-1, 0);
                }
                else if (command == "down")
                {
                    Move(1, 0);
                }
            }
        }

        private static void PopulateMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix[i].Length; j++)
                {                    
                    if (matrix[i][j] == 'S')
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

        private static void Move(int row, int col)
        {
            matrix[playerRow][playerCol] = '-';

            if (!IsInside(playerRow + row, playerCol + col))
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
                Print();
                Environment.Exit(0);
            }

            if (matrix[playerRow + row][playerCol + col] == 'O')
            {
                matrix[playerRow + row][playerCol + col] = '-';

                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        if (matrix[i][j] == 'O')
                        {
                            playerRow = i;
                            playerCol = j;
                        }
                    }
                }

                matrix[playerRow][playerCol] = 'S';
            }
            else if (char.IsDigit(matrix[playerRow + row][playerCol + col]))
            {
                playerRow += row;
                playerCol += col;

                starPower += int.Parse(matrix[playerRow][playerCol].ToString());

                matrix[playerRow][playerCol] = 'S';

                if (starPower >= 50)
                {
                    Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                    Print();
                    Environment.Exit(0);
                }                
            }
            else
            {
                playerRow += row;
                playerCol += col;
                matrix[playerRow][playerCol] = 'S';
            }
        }

        private static void Print()
        {
            Console.WriteLine($"Star power collected: {starPower}");

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}