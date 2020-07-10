﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P04.OnlineRadioDatabase.Exceptions
{
    public class InvalidSongSecondsException : InvalidSongLengthException
    {
        public InvalidSongSecondsException(string message) : base(message)
        {
        }
    }
}
