﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radians_to_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double rad = double.Parse(Console.ReadLine());
            double deg = rad * (180 / Math.PI);
            Console.WriteLine("Degrees = {0}", Math.Round(deg, 0));
        }
    }
}
