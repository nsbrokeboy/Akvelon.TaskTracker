using System;

namespace Akvelon.TaskTracker.BLL.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}