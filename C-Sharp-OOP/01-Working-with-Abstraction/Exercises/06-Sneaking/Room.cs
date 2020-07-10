using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    public class Room
    {
        public Room(int rows)
        {
            this.Matrix = new char[rows][];
            this.InitializeRoom();
        }

        public char[][] Matrix { get; set; }

        public int SamRow { get; set; }

        public int SamCol { get; set; }

        private void InitializeRoom()
        {
            for (int row = 0; row < this.Matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                    .ToCharArray();

                this.Matrix[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    this.Matrix[row][col] = input[col];
                }
            }
        }

        public void FindSam()
        {            
            for (int row = 0; row < this.Matrix.GetLength(0); row++)
            {
                this.Matrix[row] = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < this.Matrix[row].Length; col++)
                {
                    if (this.Matrix[row][col] == 'S')
                    {
                        SamRow = row;
                        SamCol = col;
                    }
                }
            }
        }

        public void MoveEnemies()
        {
            for (int row = 0; row < this.Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.Matrix[row].Length; col++)
                {
                    if (this.Matrix[row][col] == 'd')
                    {
                        if (col == 0)
                        {
                            this.Matrix[row][col] = 'b';
                        }

                        else
                        {
                            this.Matrix[row][col] = '.';
                            this.Matrix[row][col - 1] = 'd';
                        }

                        continue;
                    }

                    if (this.Matrix[row][col] == 'b')
                    {
                        if (col == this.Matrix[row].Length - 1)
                        {
                            this.Matrix[row][col] = 'd';
                        }

                        else
                        {
                            this.Matrix[row][col] = '.';
                            this.Matrix[row][col + 1] = 'b';
                            col++;
                        }
                    }
                }
            }
        }

        public bool CaughtByEnemy()
        {
            for (int col = 0; col < SamCol; col++)
            {
                if (this.Matrix[SamRow][col] == 'b')
                {
                    return true;
                }
            }

            for (int col = SamCol + 1; col < this.Matrix[SamRow].Length; col++)
            {
                if (this.Matrix[SamRow][col] == 'd')
                {
                    return true;
                }
            }

            return false;
        }

        public void PrintField()
        {
            foreach (var row in this.Matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        public bool CheckForNikoladze()
        {
            for (int col = 0; col < this.Matrix[SamRow].Length; col++)
            {
                if (Matrix[SamRow][col] == 'N')
                {
                    Matrix[SamRow][col] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    PrintField();

                    return true;
                }
            }

            return false;
        }
    }
}
