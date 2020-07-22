using System;
using System.Collections.Generic;

namespace P05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Person> people = new List<Person>();

            while (input != "END")
            {
                string[] personArgs = input
                    .Split();

                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);
                string town = personArgs[2];

                Person person = new Person(name, age, town);

                people.Add(person);

                input = Console.ReadLine();
            }

            int personNumber = int.Parse(Console.ReadLine());

            Person currentPerson = people[personNumber - 1];

            int equalPeople = 0;
            int notEqualPeople = 0;
                        
            for (int i = 0; i < people.Count; i++)
            {
                if (currentPerson.CompareTo(people[i]) == 0)
                {
                    equalPeople++;
                }
                else
                {
                    notEqualPeople++;
                }
            }

            if (equalPeople > 1)
            {
                Console.WriteLine($"{equalPeople} {notEqualPeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
