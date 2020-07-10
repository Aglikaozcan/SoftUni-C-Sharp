using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement
{
    class Program
    {
        static void Main(string[] args)
        {
            string gender = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int staj = int.Parse(Console.ReadLine());

            int retirementAge = 0;
            int retirementStaj = 0;
            bool isGender = gender == "female" || gender == "male";

            if (isGender)
            {
                if (gender == "female")
                {
                    retirementAge = 61;
                    retirementStaj = 35;
                }
                else if (gender == "male")
                {
                    retirementAge = 64;
                    retirementStaj = 38;
                }

                if (age >= retirementAge && staj >= retirementStaj)
                {
                    Console.WriteLine($"Ready to retire at {age} and {staj} years of experience!");
                }
                else if (age < retirementAge && staj >= retirementStaj)
                {
                    Console.WriteLine($"Worked enough, but not old enough. Years left to retirement: {retirementAge - age}.");
                }
                else if (age >= retirementAge && staj < retirementStaj)
                {
                    Console.WriteLine($"Old enough, but haven't worked enough. Work experience left to retirement: {retirementStaj - staj}.");
                }
                else if (age < retirementAge && staj < retirementStaj)
                {
                    Console.WriteLine($"Too early. Years left to retirement: {retirementAge - age}. Work experience left to retirement: {retirementStaj - staj}.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
