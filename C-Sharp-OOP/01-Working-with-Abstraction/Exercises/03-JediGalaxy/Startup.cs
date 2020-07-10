namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new string[] { " " }
                , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            var galaxy = new Galaxy(rows, cols);

            string command = Console.ReadLine();
            long ivoPoints = 0;

            while (command != "Let the Force be with you")
            {
                int[] ivoCoordinates = command
                    .Split(new string[] { " " }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var ivo = new Player();
                ivo.Row = ivoCoordinates[0];
                ivo.Col = ivoCoordinates[1];

                int[] evilCoordinates = Console.ReadLine()
                    .Split(new string[] { " " }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var evil = new Player();
                evil.Row = evilCoordinates[0];
                evil.Col = evilCoordinates[1];

                while (evil.Row >= 0 && evil.Col >= 0)
                {
                    if (galaxy.IsInside(evil.Row, evil.Col))
                    {
                        galaxy.Matrix[evil.Row, evil.Col] = 0;
                    }

                    evil.Row--;
                    evil.Col--;
                }

                while (ivo.Row >= 0 && ivo.Col < galaxy.Matrix.GetLength(1))
                {
                    if (galaxy.IsInside(ivo.Row, ivo.Col))
                    {
                        ivoPoints += galaxy.Matrix[ivo.Row, ivo.Col];
                    }

                    ivo.Col++;
                    ivo.Row--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(ivoPoints);
        }
    }
}
