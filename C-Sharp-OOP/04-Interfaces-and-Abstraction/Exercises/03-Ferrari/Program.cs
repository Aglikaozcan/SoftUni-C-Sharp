namespace P03.Ferrari
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            string driverName = Console.ReadLine();

            Ferrari ferrari = new Ferrari(driverName);

            Console.WriteLine(ferrari);
        }
    }
}
