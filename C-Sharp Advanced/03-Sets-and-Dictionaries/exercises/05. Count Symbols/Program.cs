using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine()
                .Trim()
                .ToCharArray();

            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];

                if (symbols.ContainsKey(symbol) == false)
                {
                    symbols[symbol] = 0;
                }
                symbols[symbol]++;
            }

            foreach (var symbolKvp in symbols)
            {
                Console.WriteLine($"{symbolKvp.Key}: {symbolKvp.Value} time/s");
            }
        }
    }
}
