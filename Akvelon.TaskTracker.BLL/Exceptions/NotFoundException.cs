using System;

namespace Akvelon.TaskTracker.BLL.Exceptions
{
    /// <summary>
    /// Custom exception for not found data
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}