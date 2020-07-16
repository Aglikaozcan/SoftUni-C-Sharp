using System;

namespace _06.BombTheBasement
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split();

            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            var bombParameters = Console.ReadLine().Split();

            int targetRow = int.Parse(bombParameters[0]);
            int targetColumn = int.Parse(bombParameters[1]);
            int radius = int.Parse(bombParameters[3]);

            var basement = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                basement[i] = new int[cols];  //запълваме с нули по дефиниция              
            }

            //запълваме с единици ударените клетки

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    double distance = Math.Sqrt(Math.Pow(i - targetRow, 2) + Math.Pow(j - targetColumn, 2));

                    if (distance <= radius)
                    {
                        basement[i][j] = 1;
                    }
                }
            }
        }
    }
}
