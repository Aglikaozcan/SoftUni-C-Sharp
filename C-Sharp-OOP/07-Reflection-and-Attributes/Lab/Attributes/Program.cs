using System;

namespace Attributes
{
    [Flags]
    public enum Color
    {
        Red,
        Green,
        Blue
    }

    [Author]
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintColor(Color.Blue | Color.Green);
        }

        public static void PrintColor(Color color)
        {
            if (color.HasFlag(Color.Green))
            {

            }
        }
    }    
}
