using System;

namespace _02.TronRacers
{
    class Program
    {
        static char[][] matrix;
        static int firstPlayerRow;
        static int firstPlayerCol;
        static int secondPlayerRow;
        static int secondPlayerCol;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            matrix = new char[n][];

            PopulateMatrix();

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                string firstPlayerCommand = commands[0];
                string secondPlayerCommand = commands[1];

                if (firstPlayerCommand == "right")
                {
                    if (firstPlayerCol + 1 >= n)
                    {
                        firstPlayerCol = 0;
                    }
                    else
                    {
                        firstPlayerCol += 1;
                    }
                }
                else if (firstPlayerCommand == "left")
                {
                    if (firstPlayerCol - 1 < 0)
                    {
                        firstPlayerCol = n - 1;
                    }
                    else
                    {
                        firstPlayerCol -= 1;
                    }
                }
                else if (firstPlayerCommand == "up")
                {
                    if (firstPlayerRow - 1 < 0)
                    {
                        firstPlayerRow = n - 1;
                    }
                    else
                    {
                        firstPlayerRow -= 1;
                    }
                }
                else if (firstPlayerCommand == "down")
                {
                    if (firstPlayerRow + 1 >= n)
                    {
                        firstPlayerRow = 0;
                    }
                    else
                    {
                        firstPlayerRow += 1;
                    }
                }

                if (matrix[firstPlayerRow][firstPlayerCol] == 's')
                {
                    matrix[firstPlayerRow][firstPlayerCol] = 'x';
                    break;
                }

                matrix[firstPlayerRow][firstPlayerCol] = 'f';

                if (secondPlayerCommand == "right")
                {
                    if (secondPlayerCol + 1 >= n)
                    {
                        secondPlayerCol = 0;
                    }
                    else
                    {
                        secondPlayerCol += 1;
                    }
                }
                else if (secondPlayerCommand == "left")
                {
                    if (secondPlayerCol - 1 < 0)
                    {
                        secondPlayerCol = n - 1;
                    }
                    else
                    {
                        secondPlayerCol -= 1;
                    }
                }
                else if (secondPlayerCommand == "up")
                {
                    if (secondPlayerRow - 1 < 0)
                    {
                        secondPlayerRow = n - 1;
                    }
                    else
                    {
                        secondPlayerRow -= 1;
                    }
                }
                else if (secondPlayerCommand == "down")
                {
                    if (secondPlayerRow + 1 >= n)
                    {
                        secondPlayerRow = 0;
                    }
                    else
                    {
                        secondPlayerRow += 1;
                    }
                }

                if (matrix[secondPlayerRow][secondPlayerCol] == 'f')
                {
                    matrix[secondPlayerRow][secondPlayerCol] = 'x';
                    break;
                }

                matrix[secondPlayerRow][secondPlayerCol] = 's';
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void PopulateMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'f')
                    {
                        firstPlayerRow = i;
                        firstPlayerCol = j;
                    }
                    else if (matrix[i][j] == 's')
                    {
                        secondPlayerRow = i;
                        secondPlayerCol = j;
                    }
                }
            }
        }
    }
}