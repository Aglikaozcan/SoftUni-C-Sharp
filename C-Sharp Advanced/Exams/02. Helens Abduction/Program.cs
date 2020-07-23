using System;

namespace _02.HelensAbduction
{
    class Program
    {
        static char[][] field;
        static int parisRow;
        static int parisCol;
        static int helenRow;
        static int helenCol;
        static int energy;
        static int spawnRow;
        static int spawnCol;

        static void Main(string[] args)
        {
            energy = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            field = new char[rows][];           
            
            PopulateField();            

            while (true)
            {
                var input = Console.ReadLine().Split();

                var command = input[0];
                spawnRow = int.Parse(input[1]);
                spawnCol = int.Parse(input[2]);

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

        private static void PopulateField()
        {
            for (int i = 0; i < field.Length; i++)
            {
                field[i] = Console.ReadLine().ToCharArray();

                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 'P')
                    {
                        parisRow = i;
                        parisCol = j;
                    }
                    else if (field[i][j] == 'H')
                    {
                        helenRow = i;
                        helenCol = j;
                    }
                }
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < field.Length & col >= 0 && col < field[row].Length;
        }

        private static void Move(int row, int col)
        {
            field[spawnRow][spawnCol] = 'S';
            field[parisRow][parisCol] = '-';
            energy--;

            if (IsInside(parisRow + row, parisCol + col))
            {
                parisRow += row;
                parisCol += col;

                if (field[parisRow][parisCol] == 'S')
                {
                    energy -= 2;
                }
                else if (field[parisRow][parisCol] == 'H')
                {
                    field[parisRow][parisCol] = '-';
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                    PrintField();
                    Environment.Exit(0);
                }

                if (energy <= 0)
                {
                    field[parisRow][parisCol] = 'X';
                    Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                    PrintField();
                    Environment.Exit(0);
                }                
            } 
        }

        private static void PrintField()
        {
            foreach (var row in field)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}