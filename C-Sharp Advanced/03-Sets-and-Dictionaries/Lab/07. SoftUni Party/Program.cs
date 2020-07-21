using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var vip = new HashSet<string>();
            var regular = new HashSet<string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "PARTY")
                {
                    break;
                }

                var matchedVipGuest = Regex.Match(line, @"^[\d]\w+$");

                if (matchedVipGuest.Success)
                {
                    vip.Add(line);
                }
                else
                {
                    regular.Add(line);
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    Console.WriteLine(vip.Count + regular.Count);

                    foreach (var name in vip)
                    {
                        Console.WriteLine(name);
                    }

                    foreach (var name in regular)
                    {
                        Console.WriteLine(name);
                    }

                    break;
                }

                if (vip.Contains(line))
                {
                    vip.Remove(line);
                }
                else if (regular.Contains(line))
                {
                    regular.Remove(line);
                }
            }
        }
    }
}
