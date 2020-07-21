using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> numbers = new HashSet<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] tokens = input.Split(", ");
                string command = tokens[0];
                string plateNumber = tokens[1];

                if (command == "IN")
                {
                    numbers.Add(plateNumber);
                }
                else
                {
                    numbers.Remove(plateNumber);
                }
            }

            if (numbers.Count > 0)
            {
                foreach (var car in numbers)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }            
        }
    }
}
