using System;

namespace P06_Sneaking
{
    public class Startup
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            var room = new Room(rows);
            room.FindSam();

            var directions = Console.ReadLine()
                .ToCharArray();

            foreach (var direction in directions)
            {
                room.MoveEnemies();

                bool samDied = room.CaughtByEnemy();

                if (samDied)
                {
                    room.Matrix[room.SamRow][room.SamCol] = 'X';
                    Console.WriteLine($"Sam died at {room.SamRow}, {room.SamCol}");
                    room.PrintField();
                    return;
                }

                room.Matrix[room.SamRow][room.SamCol] = '.';
                bool nikoladzeDied;

                switch (direction)
                {
                    case 'U':
                        room.SamRow--;
                        room.Matrix[room.SamRow][room.SamCol] = 'S';
                        nikoladzeDied = room.CheckForNikoladze();

                        if (nikoladzeDied)
                        {
                            return;
                        }

                        break;

                    case 'D':
                        room.SamRow++;
                        room.Matrix[room.SamRow][room.SamCol] = 'S';
                        nikoladzeDied = room.CheckForNikoladze();

                        if (nikoladzeDied)
                        {
                            return;
                        }

                        break;

                    case 'L':
                        room.SamCol--;
                        room.Matrix[room.SamRow][room.SamCol] = 'S';
                        break;

                    case 'R':
                        room.SamCol++;
                        room.Matrix[room.SamRow][room.SamCol] = 'S';
                        break;
                }
            }
        }
    }
}
