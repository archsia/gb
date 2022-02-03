using System;

namespace HomeWork.Two
{
    [Serializable]
    internal class TooManyAttemptLoginException : Exception
    {
        public TooManyAttemptLoginException()
        {
        }

        public TooManyAttemptLoginException(string? message) : base(message)
        {
        }

        public TooManyAttemptLoginException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}