namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var tires = new List<Tire[]>();
            var engines = new List<Engine>();
            var cars = new List<Car>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "No more tires")
                {
                    break;
                }

                var commandArgs = command.Split();
                int counter = 0;
                Tire[] tiresSet = new Tire[4];

                for (int i = 0; i < commandArgs.Length - 1; i += 2)
                {
                    int year = int.Parse(commandArgs[i]);
                    double pressure = double.Parse(commandArgs[i + 1]);

                    var currentTire = new Tire(year, pressure);

                    tiresSet[counter] = currentTire;
                    counter++;
                }

                tires.Add(tiresSet);
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Engines done")
                {
                    break;
                }

                int horsePower = int.Parse(input.Split()[0]);
                double cubicCapacity = double.Parse(input.Split()[1]);
                var currentEngine = new Engine(horsePower, cubicCapacity);

                engines.Add(currentEngine);
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Show special")
                {                  
                    break;
                }

                var tokens = input.Split();

                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                int fuelQuantity = int.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                var currentCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);

                cars.Add(currentCar);
            }

            foreach (var car in cars)
            {
                double pressureSum = 0.0;

                for (int i = 0; i < car.Tires.Length; i++)
                {
                    pressureSum += car.Tires[i].Pressure;
                }

                bool enoughFuel = Car.Drive(20, car);

                if (enoughFuel &&
                    car.Year >= 2017 &&
                    car.Engine.HorsePower > 330 &&
                    pressureSum > 9 && pressureSum < 10)
                {
                    car.FuelQuantity -= (20 * car.FuelConsumption / 100);

                    Console.WriteLine(Car.WhoAmI(car));
                }
            }
        }
    }
}