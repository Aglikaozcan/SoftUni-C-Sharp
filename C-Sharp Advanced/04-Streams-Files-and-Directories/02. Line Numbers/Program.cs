using System;
using System.IO;

namespace _02._Line_Numbers_2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../text.txt"))
            {
                int counter = 1;

                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        int letterCount = 0;
                        int symbolsCount = 0;

                        foreach (var @char in line)
                        {
                            if (char.IsLetter(@char))
                            {
                                letterCount++;
                            }
                            else if (char.IsPunctuation(@char))
                            {
                                symbolsCount++;
                            }
                        }

                        writer.WriteLine($"Line {counter}: {line} ({letterCount})({symbolsCount})");

                        counter++;

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
