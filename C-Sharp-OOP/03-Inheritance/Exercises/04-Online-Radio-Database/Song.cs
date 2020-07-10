using P04.OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.OnlineRadioDatabase
{
    public class Song
    {
        private string artistName;
        private string songName;
        private string length;

        public Song(string artistName, string songName, string length)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.Length = length;
        }

        public string ArtistName
        {
            get => this.artistName;
            private set
            {
                if (value.Length < 3 || value.Length > 20 )
                {
                    throw new InvalidArtistNameException("Artist name should be between 3 and 20 symbols.");
                }

                this.artistName = value;
            }
        }

        public string SongName
        {
            get => this.songName;
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException("Song name should be between 3 and 30 symbols.");
                }

                this.songName = value;
            }
        }

        public string Length
        {
            get => this.length;
            private set
            {
                string[] tokens = value.Split(':');
                int minutes = int.Parse(tokens[0]);
                int seconds = int.Parse(tokens[1]);

                if (minutes < 0 || minutes > 14)
                {
                    throw new InvalidSongMinutesException("Song minutes should be between 0 and 14.");
                }

                if (seconds < 0 || seconds > 59)
                {
                    throw new InvalidSongSecondsException("Song seconds should be between 0 and 59.");
                }

                this.length = value;
            }


        }
    }
}
