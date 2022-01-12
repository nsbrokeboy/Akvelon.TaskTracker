using Akvelon.TaskTracker.DAL.Enums;

namespace Akvelon.TaskTracker.DAL.Entities
{
    /// <summary>
    /// This class defines the entity of Task
    /// </summary>
    public class ProjectTask
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ProjectTaskStatus ProjectTaskStatus { get; set; }

        public int Priority { get; set; }

        public int ProjectId { get; set; }
        
        public Project Project { get; set; }
    }
}