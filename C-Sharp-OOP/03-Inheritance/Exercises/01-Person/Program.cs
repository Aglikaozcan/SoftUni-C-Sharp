namespace P01.Person
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            try
            {
                Person person = new Person(name, age);
                Child child = new Child(name, age);

                Console.WriteLine(person.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
