using Akvelon.TaskTracker.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Akvelon.TaskTracker.DAL.DataContext
{
    /// <summary>
    /// Database context
    /// </summary>
    public class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options)
        {
        }

        public TaskTrackerDbContext()
        {
        }

        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}