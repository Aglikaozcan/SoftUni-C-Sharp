using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concatenate_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("First name = ");
            string FirstName = Console.ReadLine();
            Console.Write("Last name = ");
            string LastName = Console.ReadLine();
            Console.Write("Age = ");
            int Age = int.Parse(Console.ReadLine());
            Console.Write("Town = ");
            string Town = Console.ReadLine();
            Console.WriteLine("You are " + FirstName + " " + LastName + ", " + "a " + Age + "-years old person from " + Town + ".");
        }
    }
}
