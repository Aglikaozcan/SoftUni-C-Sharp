namespace ExplicitInterfaces
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] citizenArgs = line
                    .Split();

                string name = citizenArgs[0];
                string country = citizenArgs[1];
                int age = int.Parse(citizenArgs[2]);

                Citizen citizen = new Citizen(name, country, age);

                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());

                line = Console.ReadLine();
            }
        }
    }
}
