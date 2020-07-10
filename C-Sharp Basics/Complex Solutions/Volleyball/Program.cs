using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int homeWeekend = int.Parse(Console.ReadLine());

            int weekendSof = 48 - homeWeekend;
            double playSat = weekendSof * 3.0 / 4;
            double playHoliday = holidays * 2.0 / 3;
            double totalGames = playSat + homeWeekend + playHoliday;

            if (year == "leap")
            {
                double extraLeap = totalGames * 0.15;
                double games = totalGames + extraLeap;
                Console.WriteLine(Math.Floor(games));
            }
            else if (year == "normal")
            {
                Console.WriteLine(Math.Floor(totalGames));
            }
        }
    }
}
