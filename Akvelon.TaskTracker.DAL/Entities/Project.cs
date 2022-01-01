using System;
using System.Collections.Generic;
using Akvelon.TaskTracker.DAL.Enums;

namespace Akvelon.TaskTracker.DAL.Entities
{
    /// <summary>
    /// This class defines the entity of Project
    /// </summary>
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        public ProjectStatus Status { get; set; }
        
        public IEnumerable<Task> Tasks { get; set; }

        public int Priority { get; set; }
    }
}