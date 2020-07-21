using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < count; i++)
            {
                string[] personArgs = Console.ReadLine().Split();

                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            List<Person> peopleOverThirty = family
                .GetPeopleOverThirty()
                .OrderBy(x => x.Name)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, peopleOverThirty));
        }
    }
}
