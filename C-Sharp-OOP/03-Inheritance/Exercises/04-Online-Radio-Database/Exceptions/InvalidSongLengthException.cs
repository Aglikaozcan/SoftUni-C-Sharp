using System;
using System.Collections.Generic;
using System.Text;

namespace P04.OnlineRadioDatabase.Exceptions
{
    public class InvalidSongLengthException : InvalidSongException
    {
        public InvalidSongLengthException(string message) 
            : base(message)
        {
        }
    }
}
