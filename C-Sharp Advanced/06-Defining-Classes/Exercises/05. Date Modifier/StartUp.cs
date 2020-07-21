using System;

namespace _05._Date_Modifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            var diff = new DateModifier();

            Console.WriteLine(diff.FindDifference(firstDate, secondDate));
        }
    }
}
