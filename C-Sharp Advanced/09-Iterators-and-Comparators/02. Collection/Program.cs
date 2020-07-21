using System;
using System.Linq;

namespace P02.Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            ListyIterator<string> listIterator = null;

            while (input != "END")
            {
                string[] splitedInput = input.Split();

                string command = splitedInput[0];

                if (command == "Create")
                {
                    listIterator = new ListyIterator<string>(splitedInput.Skip(1).ToList());
                }
                else if (command == "Move")
                {
                    Console.WriteLine(listIterator.Move());
                }
                else if (command == "Print")
                {
                    Console.WriteLine(listIterator.Print());
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listIterator.HasNext());
                }
                else if (command == "PrintAll")
                {
                    foreach (var element in listIterator)
                    {
                        Console.Write(element + " ");
                    }
                    Console.WriteLine();
                }

                input = Console.ReadLine();
            }
        }
    }
}
