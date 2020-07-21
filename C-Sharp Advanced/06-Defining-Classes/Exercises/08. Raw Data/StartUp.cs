namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire[] tiresSet = new Tire[4];
                int counter = 0;

                for (int j = 5; j < input.Length - 1; j += 2)
                {
                    double pressure = double.Parse(input[j]);
                    int age = int.Parse(input[j + 1]);

                    Tire tire = new Tire(pressure, age);

                    tiresSet[counter] = tire;
                    counter++;
                }

                Car car = new Car(model, engine, cargo, tiresSet);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            List<string> result = null; 

            if (command == "fragile")
            {
                result = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(t => t.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();                
            }
            else
            {
                result = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();
            }

            foreach (var car in result)
            {
                Console.WriteLine(car);
            }
        }
    }
}