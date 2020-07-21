using System;
using System.Collections.Generic;
using System.IO;

namespace _01._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string specialSymbols = "-.,!?";

            int counter = 0;

            using (var reader = new StreamReader("../../../text.txt"))
            {

                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    while (true)
                    {
                        var line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        if (counter % 2 == 0)
                        {
                            string changedLine = string.Empty;

                            foreach (var charr in line)
                            {
                                if (specialSymbols.Contains(charr))
                                {
                                    changedLine += '@';
                                }
                                else
                                {
                                    changedLine += charr;
                                }
                            }

                            string[] splitedLine = changedLine.Split();

                            Array.Reverse(splitedLine);

                            writer.WriteLine(string.Join(" ", splitedLine));
                        }

                        counter++;
                    }
                }
            }
        }
    }
}
