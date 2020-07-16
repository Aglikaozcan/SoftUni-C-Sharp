using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStations = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();            

            for (int i = 0; i < numberOfStations; i++)
            {
                int[] stationInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(stationInfo);
            }

            int index = 0;
            int tank = 0;

            while (true)
            {
                foreach (var pump in pumps)
                {
                    int petrol = pump[0];
                    int distance = pump[1];

                    tank += petrol - distance;

                    if (tank < 0)
                    {
                        var currentPump = pumps.Dequeue();
                        pumps.Enqueue(currentPump);
                        index++;
                    }
                }
            }

        }
    }
}
