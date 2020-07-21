using System;
using System.Collections.Generic;
using System.Linq;

namespace P13.FamilyTree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string dateOrname = Console.ReadLine();

            List<Connection> connections = new List<Connection>();
            List<Person> peopleInfo = new List<Person>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                if (input.Contains("-"))
                {
                    string[] splitedInput = input.Split(" - ");

                    string parentArgument = splitedInput[0];
                    string childArgument = splitedInput[1];

                    Person parent = new Person(parentArgument);
                    Person child = new Person(childArgument);

                    Connection connection = new Connection(parent, child);

                    connections.Add(connection);
                }
                else
                {
                    string[] splitedInput = input.Split();

                    string name = $"{splitedInput[0]} {splitedInput[1]}";
                    string birthdate = splitedInput[2];

                    Person person = new Person(name, birthdate);

                    peopleInfo.Add(person);
                }

                input = Console.ReadLine();
            }

            Person mainPerson = peopleInfo
                .FirstOrDefault(x => x.Birthdate == dateOrname || x.Name == dateOrname);

            var filteredConnections = connections
                .Where(x => x.Parent.Birthdate == mainPerson.Birthdate
                || x.Child.Birthdate == mainPerson.Birthdate
                || x.Parent.Name == mainPerson.Name
                || x.Child.Name == mainPerson.Name)
                .ToList();

            Result result = new Result();

            result.MainPerson = mainPerson;

            foreach (var connection in filteredConnections)
            {
                bool isChildByDate = connection.Child.Birthdate == mainPerson.Birthdate;
                bool isChildByName = connection.Child.Name == mainPerson.Name;

                bool isParentByDate = connection.Parent.Birthdate == mainPerson.Birthdate;
                bool isParentByName = connection.Parent.Name == mainPerson.Name;

                if (isChildByDate || isChildByName)
                {
                    Person parent = peopleInfo
                        .FirstOrDefault(x => x.Name == connection.Parent.Name
                            || x.Birthdate == connection.Parent.Birthdate);

                    result.Parents.Add(parent);
                }
                else if (isParentByDate || isParentByName)
                {
                    Person child = peopleInfo
                        .FirstOrDefault(x => x.Name == connection.Child.Name
                           || x.Birthdate == connection.Child.Birthdate);

                    result.Children.Add(child);
                }
            }

            Console.WriteLine(result);
        }
    }
}
