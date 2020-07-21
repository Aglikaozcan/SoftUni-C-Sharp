using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Rectangle_Intersection_2
{
    public class Rectangle
    {
        public Rectangle(string id, int width, int height, int x, int y)
        {
            Id = id;
            Width = width;
            Height = height;
            X = x;
            Y = y;
        }

        public string Id { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
