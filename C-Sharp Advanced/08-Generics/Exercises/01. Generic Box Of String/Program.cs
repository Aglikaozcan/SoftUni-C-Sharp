using System;

namespace P01.GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                string content = Console.ReadLine();
                Box<string> boxWithString = new Box<string>(content);
                Console.WriteLine(boxWithString.ToString());
            }
        }
    }
}
