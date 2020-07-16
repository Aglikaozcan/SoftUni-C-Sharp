using System;
using System.Collections.Generic;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split();

            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            char[][] matrix = new char[rows][];

            string snake = Console.ReadLine();

            Queue<char> snakeQueue = new Queue<char>(snake.ToCharArray());
            
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new char[cols];

                if (i % 2 == 0)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        var symbol = snakeQueue.Dequeue();

                        matrix[i][j] = symbol;
                        snakeQueue.Enqueue(symbol);
                    }
                }
                else
                {
                    for (int j = cols - 1; j >= 0; j--)
                    {
                        var symbol = snakeQueue.Dequeue();

                        matrix[i][j] = symbol;
                        snakeQueue.Enqueue(symbol);
                    }
                }                
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
