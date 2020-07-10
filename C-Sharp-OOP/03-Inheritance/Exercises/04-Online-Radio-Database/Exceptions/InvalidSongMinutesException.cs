using System;
using System.Collections.Generic;
using System.Text;

namespace P04.OnlineRadioDatabase.Exceptions
{
    public class InvalidSongMinutesException : InvalidSongLengthException
    {
        public InvalidSongMinutesException(string message) : base(message)
        {
        }
    }
}
