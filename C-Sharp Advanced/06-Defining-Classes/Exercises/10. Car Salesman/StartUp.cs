namespace _09.CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                string model = input[0];
                int power = int.Parse(input[1]);

                Engine engine = null;

                if (input.Length == 2)
                {
                    engine = new Engine(model, power);
                }
                else if (input.Length == 4)
                {
                    int displacement = int.Parse(input[2]);
                    string efficiency = input[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }
                else
                {
                    if (int.TryParse(input[2], out int displacement))
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, input[2]);
                    }
                }

                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                //“<Model> <Engine> <Weight> <Color>
                string model = input[0];

                var engine = engines
                    .Where(x => x.Model == input[1])
                    .FirstOrDefault();                    

                Car car = null;

                if (input.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (input.Length == 4)
                {
                    int weight = int.Parse(input[2]);
                    string color = input[3];

                    car = new Car(model, engine, weight, color);
                }
                else
                {
                    if (int.TryParse(input[2], out int weight))
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        car = new Car(model, engine, weight, input[2]);
                    }
                }

                cars.Add(car);
            }


            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
