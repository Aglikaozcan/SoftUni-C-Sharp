using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Auto_Repair_and_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vehicles = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> waitingCars = new Queue<string>(vehicles);
            Stack<string> servicedCars = new Stack<string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }
                else if (command == "Service" && waitingCars.Any())
                {
                    string currentCar = waitingCars.Dequeue();
                    Console.WriteLine($"Vehicle {currentCar} got served.");
                    servicedCars.Push(currentCar);
                }
                else if (command == "History")
                {
                    Console.WriteLine(string.Join(", ", servicedCars));
                }
                else
                {
                    string modelName = command.Split("-")[1];

                    if (waitingCars.Contains(modelName))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }
            }

            if (waitingCars.Any())
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", waitingCars)}");
            }

            if (servicedCars.Any())
            {
                Console.WriteLine($"Served vehicles: {string.Join(", ", servicedCars)}");
            }
        }
    }
}
