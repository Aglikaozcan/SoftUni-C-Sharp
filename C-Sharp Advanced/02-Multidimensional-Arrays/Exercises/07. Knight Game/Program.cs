using System;
using System.Linq;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            var matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();                 
            }

            Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(r => string.Join("", r))));
        }
    }
}
