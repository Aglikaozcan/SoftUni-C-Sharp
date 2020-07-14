using System;

namespace P04.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            var phoneNumbers = Console.ReadLine().Split();
            var urls = Console.ReadLine().Split();

            var smartphone = new Smartphone();

            foreach (var phoneNumber in phoneNumbers)
            {
                Console.WriteLine(smartphone.Call(phoneNumber));
            }

            foreach (var url in urls)
            {
                Console.WriteLine(smartphone.Browse(url));
            }
        }
    }
}
