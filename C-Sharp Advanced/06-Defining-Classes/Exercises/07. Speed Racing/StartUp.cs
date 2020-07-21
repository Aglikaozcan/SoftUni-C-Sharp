using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Speed_Racing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);

                Car car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            while (true)
            {
                var command = Console.ReadLine().Split();

                if (command[0] == "End")
                {
                    break;
                }

                string model = command[1];
                int traveledDistance = int.Parse(command[2]);

                var car = cars.Where(c => c.Model == model).First();
                car.CheckFuel(traveledDistance);
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
