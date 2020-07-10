using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_in_the_Figure
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            bool outRect1 = (x < 0 || x > 3 * h) || (y < 0 || y > h);
            bool outRect2 = (x < h || x > 2 * h) || (y < h || y > 4 * h);

            bool inRect1 = (x > 0 && x < 3 * h) && (y > 0 && y < h);
            bool inRect2 = (x > h && x < 2 * h) && (y > h && y < 4 * h);

            bool commonBorder = (x > h && x < 2 * h) && y == h;

            if (outRect1 && outRect2)
            {
                Console.WriteLine("outside");
            }
            else if (inRect1 || inRect2 || commonBorder)
            {
                Console.WriteLine("inside");
            }
            else
            {
                Console.WriteLine("border");
            }
        }
    }
}
