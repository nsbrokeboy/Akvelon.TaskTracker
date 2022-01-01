using Akvelon.TaskTracker.DAL.Enums;

namespace Akvelon.TaskTracker.DAL.Entities
{
    /// <summary>
    /// This class defines the entity of Task
    /// </summary>
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TaskStatus TaskStatus { get; set; }

        public int Priority { get; set; }
    }
}