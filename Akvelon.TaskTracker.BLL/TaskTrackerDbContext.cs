using Microsoft.EntityFrameworkCore;

namespace Akvelon.TaskTracker.BLL
{
    public class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TaskTracker;Username=dvkruglyak;Password=7f4fm76d5");
            }
        }
    }
}