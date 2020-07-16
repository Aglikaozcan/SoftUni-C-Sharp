using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int durationGreenLight = int.Parse(Console.ReadLine());
            int yellowLight = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int passedCars = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                if (input == "green")
                {
                    var currentCar = cars.Dequeue();
                    var remainigSeconds = durationGreenLight;
                    var totalTime = remainigSeconds + yellowLight;

                    while (remainigSeconds > 0 && cars.Any())
                    {
                        if (currentCar.Length <= remainigSeconds)
                        {
                            remainigSeconds -= currentCar.Length;
                            passedCars++;
                        }
                        else if (currentCar.Length <= totalTime)
                        {
                            remainigSeconds = 0;
                            passedCars++;
                        }
                        else
                        {
                            for (int i = 0; i < currentCar.Length; i++)
                            {
                                totalTime--;

                                if (totalTime < 0)
                                {
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{currentCar} was hit at {currentCar[i]}.");
                                    return;
                                }
                            }
                        }
                    }

                }
                else
                {
                    cars.Enqueue(input);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
