using System;
using System.Collections.Generic;
using System.Text;

namespace P04.OnlineRadioDatabase.Exceptions
{
    public class InvalidSongException : Exception
    {
        private string message;

        public InvalidSongException(string message)
        {
            this.message = message;
        }

        public override string Message => this.message;
    }
}
