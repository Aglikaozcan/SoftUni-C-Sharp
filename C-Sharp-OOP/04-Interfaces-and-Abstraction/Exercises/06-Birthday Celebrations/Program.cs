using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            var collection = new List<IBirthable>();

            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                else if (input[0] == "Citizen")
                {
                    string name = input[1];
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string birthdate = input[4];
                    collection.Add(new Citizen(name, age, id, birthdate));
                }

                else if (input[0] == "Pet")
                {
                    string name = input[1];
                    string birthdate = input[2];
                    collection.Add(new Pet(name, birthdate));
                }
            }

            string year = Console.ReadLine();

            collection
                .Select(x => x.Birthdate)
                .Where(x => x.EndsWith(year))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
