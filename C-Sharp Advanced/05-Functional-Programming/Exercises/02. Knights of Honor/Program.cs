using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> names = Console.ReadLine()
            //    .Split()
            //    .Select(x => $"Sir {x}")
            //    .ToList();

           // Console.ReadLine()
           //     .Split()
           //     .Select(x => $"Sir {x}")
           //     .ToList()
           //     .ForEach(Console.WriteLine);

           // Console.ReadLine()
           //     .Split()
           //     .ToList()
           //     .ForEach(x => Console.WriteLine($"Sir {x}"));

            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            Func<string, string> format = x => $"Sir {x}";

            Action<List<string>> print = x => Console.WriteLine(string.Join(Environment.NewLine, x.Select(format)));

            print(names);
        }
    }
}
