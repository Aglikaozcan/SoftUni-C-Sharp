using P04.OnlineRadioDatabase.Exceptions;
using System;

namespace P04.OnlineRadioDatabase
{
    public class Program
    {
        static void Main(string[] args)
        {
            SongDatabase songDB = new SongDatabase();

            int songCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < songCount; i++)
            {
                string[] songArgs = Console.ReadLine()
                .Split(';');

                string artistName = songArgs[0];
                string songName = songArgs[1];
                string length = songArgs[2];

                try
                {
                    Song song = new Song(artistName, songName, length);

                    songDB.AddSong(song);

                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine($"Songs added: {songDB.GetSongCount()}");
            Console.WriteLine($"Playlist length: {songDB.GetTotalLengthOfSongs()}");
        }

    }
}