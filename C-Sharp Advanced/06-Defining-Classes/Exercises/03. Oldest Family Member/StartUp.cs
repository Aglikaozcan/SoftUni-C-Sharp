namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                var currentName = Console.ReadLine().Split();

                string name = currentName[0];
                int age = int.Parse(currentName[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }

            Person oldesMember = family.GetOldestMember();

            Console.WriteLine(oldesMember);
        }
    }
}