using System;
using System.Linq;

namespace PresentDelivery
{
    class Program
    {
        static char[][] matrix;
        static int santaRow;
        static int santaCol;
        static int niceKids;
        static int presents;
        static int happyKids;

        static void Main(string[] args)
        {
            presents = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            matrix = new char[rows][];

            PopulateMatrix();

            while (presents > 0)
            {
                string command = Console.ReadLine();

                if (command == "Christmas morning")
                {
                    break;
                }

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

            if (niceKids > 0 && presents == 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            matrix[santaRow][santaCol] = 'S';
            Print();

            if (niceKids == 0)
            {
                Console.WriteLine($"Good job, Santa! {happyKids} happy nice kid/s.");
            }
            else 
            {
                Console.WriteLine($"No presents for {niceKids} nice kid/s.");
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

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'S')
                    {
                        santaRow = i;
                        santaCol = j;
                    }
                    else if (matrix[i][j] == 'V')
                    {
                        niceKids++;
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
            matrix[santaRow][santaCol] = '-';

            santaRow += row;
            santaCol += col;

            if (presents == 0)
            {
                Environment.Exit(0);
            }

            if (!IsInside(santaRow, santaCol))
            {
                Console.WriteLine("Santa ran out of presents.");
                matrix[santaRow][santaCol] = 'S';
                Print();
                Console.WriteLine($"No presents for {niceKids} nice kid/s.");
                Environment.Exit(0);
            }

            if (matrix[santaRow][santaCol] == 'V')
            {
                presents--;
                niceKids--;
                happyKids++;
            }
            else if (matrix[santaRow][santaCol] == 'C')
            {
                //down
                if (IsInside(santaRow + 1, santaCol) && matrix[santaRow + 1][santaCol] == 'V')
                {
                    presents--;
                    niceKids--;
                    happyKids++;
                    matrix[santaRow + 1][santaCol] = '-';
                }
                else if (IsInside(santaRow + 1, santaCol) && matrix[santaRow + 1][santaCol] == 'X')
                {
                    presents--;
                    matrix[santaRow + 1][santaCol] = '-';
                }

                //up
                if (IsInside(santaRow - 1, santaCol) && matrix[santaRow - 1][santaCol] == 'V')
                {
                    presents--;
                    niceKids--;
                    happyKids++;
                    matrix[santaRow - 1][santaCol] = '-';
                }
                else if (IsInside(santaRow - 1, santaCol) && matrix[santaRow - 1][santaCol] == 'X')
                {
                    presents--;
                    matrix[santaRow - 1][santaCol] = '-';
                }

                //right
                if (IsInside(santaRow, santaCol + 1) && matrix[santaRow][santaCol + 1] == 'V')
                {
                    presents--;
                    niceKids--;
                    happyKids++;
                    matrix[santaRow][santaCol + 1] = '-';
                }
                else if (IsInside(santaRow, santaCol + 1) && matrix[santaRow][santaCol + 1] == 'X')
                {
                    presents--;
                    matrix[santaRow][santaCol + 1] = '-';
                }

                //left
                if (IsInside(santaRow, santaCol - 1) && matrix[santaRow][santaCol - 1] == 'V')
                {
                    presents--;
                    niceKids--;
                    happyKids++;
                    matrix[santaRow][santaCol - 1] = '-';
                }
                else if (IsInside(santaRow, santaCol - 1) && matrix[santaRow][santaCol - 1] == 'X')
                {
                    presents--;
                    matrix[santaRow][santaCol - 1] = '-';
                }
            }
        }

        private static void Print()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
