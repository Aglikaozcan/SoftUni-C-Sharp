using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.ExcelFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[][] table = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                string[] rowValues = Console.ReadLine()
                    .Split(", ");

                table[i] = rowValues;
            }

            string[] commandArgs = Console.ReadLine()
                .Split();

            string command = commandArgs[0];
            string header = commandArgs[1];

            if (command == "hide")
            {
                int headerIndex = Array.IndexOf(table[0], header);

                // трябва ни нов списък с елементите от матрицата, но без тези, които трябва да скрием
                // матрицата е разделена на две части и трябва да ги съберем

                for (int row = 0; row < table.Length; row++)
                {
                    List<string> lineToPrint = new List<string>(table[row]);

                    lineToPrint.RemoveAt(headerIndex);

                    //lineToPrint.AddRange(table[row].Take(headerIndex));
                    //lineToPrint.AddRange(table[row].Skip(headerIndex + 1));
                   
                    Console.WriteLine(string.Join(" | ", lineToPrint));
                }
            }
        }
    }
}
