using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Akvelon.TaskTracker.BLL.Exceptions;
using Akvelon.TaskTracker.DAL.DataContext;
using Akvelon.TaskTracker.DAL.Entities;
using Akvelon.TaskTracker.DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace Akvelon.TaskTracker.BLL.Services
{
    public class TaskService
    {
        private readonly TaskTrackerDbContext _context;

        public TaskService(TaskTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateTask(string name, string description, int priority,
            CancellationToken cancellationToken, ProjectTaskStatus status = ProjectTaskStatus.ToDo)
        {
            var task = new ProjectTask()
            {
                Name = name,
                Description = description,
                Priority = priority,
                ProjectTaskStatus = status
            };

            await _context.Tasks.AddAsync(task, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return task.Id;
        }

        public async Task<ProjectTask> GetTaskById(int id, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
            if (task == null)
            {
                throw new NotFoundException($"Task with {id} not found.");
            }

            return task;
        }

        public async Task<IList<ProjectTask>> GetAllTasks(CancellationToken cancellationToken)
        {
            var tasks = await _context.Tasks.ToListAsync(cancellationToken);
            if (!tasks.Any())
            {
                throw new NotFoundException("There are no tasks found");
            }

            return tasks;
        }

        public async Task UpdateTask(int taskId, string name, string description, int priority, ProjectTaskStatus status, 
            CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId, cancellationToken);
            if (task == null)
            {
                throw new NotFoundException($"Task with {taskId} not found.");
            }

            task.Name = name;
            task.Description = description;
            task.ProjectTaskStatus = status;
            task.Priority = priority;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteTask(int id, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
            if (task == null)
            {
                throw new NotFoundException($"Task with {id} not found.");
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}