using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMin = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMin;
            int arrivalTime = arrivalHour * 60 + arrivalMin;
            int difference = examTime - arrivalTime;

            if (difference >= 0 && difference <= 30)
            {
                Console.WriteLine("On time");
                if (difference != 0)
                {
                    Console.WriteLine($"{difference} minutes before the start");
                }
            }
            else if (difference > 30)
            {
                Console.WriteLine("Early");
                if (difference >= 60)
                {
                    int hh = difference / 60;
                    int mm = difference % 60;
                    Console.WriteLine($"{hh}:{mm:d2} hours before the start");
                }

                else if (difference < 60)
                {
                    Console.WriteLine($"{difference} minutes before the start");
                }

            }
            else
            {
                Console.WriteLine("late");
                difference *= -1;

                if (difference >= 60)
                {
                    int hh = difference / 60;
                    int mm = difference % 60;
                    Console.WriteLine($"{hh}:{mm:d2} hours after the start");
                }
                else if (difference < 60)
                {
                    Console.WriteLine($"{difference} minutes after the start");
                }
                
            }
        }
    }
}
