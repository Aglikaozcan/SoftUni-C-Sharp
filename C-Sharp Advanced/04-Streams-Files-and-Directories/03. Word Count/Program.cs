using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, int>();

            using (var reader = new StreamReader("../../../words.txt"))
            {
                while (true)
                {
                    var word = reader.ReadLine();

                    if (word == null)
                    {
                        break;
                    }

                    else if (!dictionary.ContainsKey(word))
                    {
                        dictionary.Add(word, 0);
                    }
                }
            }

            using (var reader = new StreamReader("../../../words.txt"))
            {
                using (var writer = new StreamWriter("../../../actualResult.txt"))
                {
                    while (true)
                    {
                        var line = reader.ReadLine();

                        if (line == null)
                        {
                            var orderedWords = dictionary.OrderByDescending(w => w.Value);

                            foreach (var word in orderedWords)
                            {
                                writer.WriteLine($"{word.Key} - {word.Value}");
                            }

                            return;
                        }

                        var words = line
                            .Split(new char[] { ',', '.', '?', '!', '-', ' ' },
                            StringSplitOptions.RemoveEmptyEntries);

                        foreach (var word in words)
                        {
                            if (dictionary.ContainsKey(word.ToLower()))
                            {
                                dictionary[word.ToLower()]++;
                            }
                        }
                    }
                }
            }
        }
    }
}


