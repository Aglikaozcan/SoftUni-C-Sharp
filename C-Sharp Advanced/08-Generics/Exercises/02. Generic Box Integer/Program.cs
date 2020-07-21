using System;

namespace P02.GenericBoxInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                int content = int.Parse(Console.ReadLine());
                Box<int> boxWithInt = new Box<int>(content);
                Console.WriteLine(boxWithInt.ToString());
            }
        }
    }
}
