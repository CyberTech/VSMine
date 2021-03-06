﻿using System;

namespace VSMine.RedmineService.Exceptions
{
    [Serializable]
    public class NotInitializedException : Exception
    {
        public NotInitializedException()
        {

        }

        public NotInitializedException(string message)
            : base(message)
        {

        }

        public NotInitializedException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
