using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());

            Stack<string> versions = new Stack<string>();
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] input = Console.ReadLine().Split();

                string commandName = input[0];

                switch (commandName)
                {
                    case "1":
                        versions.Push(text.ToString());
                        string textToAdd = input[1];
                        text.Append(textToAdd);
                        break;
                    case "2":
                        versions.Push(text.ToString());
                        int removeElementsCount = int.Parse(input[1]);
                        text.Remove(text.Length - removeElementsCount, removeElementsCount);
                        break;
                    case "3":
                        int index = int.Parse(input[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;
                    case "4":
                        text.Clear();
                        text.Append(versions.Pop());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
