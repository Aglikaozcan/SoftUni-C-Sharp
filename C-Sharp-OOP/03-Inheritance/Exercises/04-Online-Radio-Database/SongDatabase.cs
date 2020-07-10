using System;
using System.Collections.Generic;
using System.Text;

namespace P04.OnlineRadioDatabase
{
    public class SongDatabase
    {
        private List<Song> songs;

        public SongDatabase()
        {
            this.songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            this.songs.Add(song);
        }

        public string GetTotalLengthOfSongs()
        {
            int hours = 0;
            int minutes = 0;
            int seconds = 0;

            foreach (var song in this.songs)
            {
                string[] tokens = song.Length.Split(':');
                int currentMinutes = int.Parse(tokens[0]);
                int currentSeconds = int.Parse(tokens[1]);

                minutes += currentMinutes;
                seconds += currentSeconds;

                if (seconds > 59)
                {
                    minutes++;
                    seconds -= 60;
                }
                if (minutes > 59)
                {
                    hours++;
                    minutes -= 60;
                }
            }

            return $"{hours}h {minutes}m {seconds}s";
        }

        public int GetSongCount()
        {
            return this.songs.Count;
        }
    }
}
