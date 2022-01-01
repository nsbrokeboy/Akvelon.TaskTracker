using Akvelon.TaskTracker.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Akvelon.TaskTracker.DAL.DataContext
{
    public class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}