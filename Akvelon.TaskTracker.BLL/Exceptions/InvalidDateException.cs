using System;

namespace Akvelon.TaskTracker.BLL.Exceptions
{
    /// <summary>
    /// Custom exception for invalid date
    /// </summary>
    public class InvalidDateException : Exception
    {
        public InvalidDateException(string message) : base(message)
        {
        }
    }
}