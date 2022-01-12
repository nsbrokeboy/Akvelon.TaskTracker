using System;

namespace Akvelon.TaskTracker.BLL.Exceptions
{
    public class InvalidDateException : Exception
    {
        public InvalidDateException(string message) : base(message)
        {
        }
    }
}