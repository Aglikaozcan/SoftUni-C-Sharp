using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_System
{
    class Program
    {
        static void Main(string[] args)
        {
            string planet = Console.ReadLine();
            int maxDays = int.Parse(Console.ReadLine());

            double distance = 0;
            double totalDistance = 0;
            int planetDays = 0;
            double days = 0;
            bool isPlanet = planet == "Mercury" || planet == "Venus" || planet == "Mars" || planet == "Jupiter" || planet == "Saturn" || planet == "Uranus" || planet == "Neptune";

            if (isPlanet)
            {

                if (planet == "Mercury")
                {
                    distance = 0.61;
                    planetDays = 7;
                }
                else if (planet == "Venus")
                {
                    distance = 0.28;
                    planetDays = 14;
                }
                else if (planet == "Mars")
                {
                    distance = 0.52;
                    planetDays = 20;
                }
                else if (planet == "Jupiter")
                {
                    distance = 4.2;
                    planetDays = 5;
                }
                else if (planet == "Saturn")
                {
                    distance = 8.52;
                    planetDays = 3;
                }
                else if (planet == "Uranus")
                {
                    distance = 18.21;
                    planetDays = 3;
                }
                else if (planet == "Neptune")
                {
                    distance = 29.09;
                    planetDays = 2;
                }

                if (maxDays > planetDays)
                {
                    Console.WriteLine("Invalid number of days!");
                }
                else
                {
                    totalDistance = 2 * distance;
                    days = (totalDistance * 226) + maxDays;

                    Console.WriteLine($"Distance: {totalDistance:f2}");
                    Console.WriteLine($"Total number of days: {days:f2}");
                }
            }
            else
            {
                Console.WriteLine("Invalid planet name!");
            }
        }
    }
}
