using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            int freeCapacity = maxCapacity;

            var input = Console.ReadLine().Split().Reverse();

            Queue<string> halls = new Queue<string>();
            Queue<int> peopleInHall = new Queue<int>();

            foreach (var element in input)            
            {
                bool isNumber = int.TryParse(element, out int reservation);

                if (isNumber == false)
                {
                    halls.Enqueue(element);
                }
                else if (halls.Count > 0 && isNumber)                
                {
                    reservation = int.Parse(element);

                    var sumOfReservations = peopleInHall.Sum();

                    if (sumOfReservations + reservation <= maxCapacity)
                    {
                        peopleInHall.Enqueue(reservation);
                    }
                    else
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", peopleInHall)}");
                        peopleInHall.Clear();
                    }
                }
            } 
        }
    }
}