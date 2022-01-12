using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Akvelon.TaskTracker.BLL.Exceptions;
using Akvelon.TaskTracker.BLL.Services.Interfaces;
using Akvelon.TaskTracker.DAL.DataContext;
using Akvelon.TaskTracker.DAL.Entities;
using Akvelon.TaskTracker.DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace Akvelon.TaskTracker.BLL.Services.Implementations
{
    public class TaskService : ITaskService

    {
        private readonly TaskTrackerDbContext _context;

        public TaskService(TaskTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateTask(string name, string description, int priority, int projectId,
            CancellationToken cancellationToken, ProjectTaskStatus status = ProjectTaskStatus.ToDo)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId, cancellationToken);
            if (project == null)
            {
                throw new NotFoundException($"There are no project with id = {projectId}");
            }

            var task = new ProjectTask()
            {
                Name = name,
                Description = description,
                Priority = priority,
                ProjectTaskStatus = status,
                ProjectId = projectId,
            };

            project.Tasks.Add(task);

            await _context.Tasks.AddAsync(task, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return task.Id;
        }

        public async Task<ProjectTask> GetTaskById(int id, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
            if (task == null)
            {
                throw new NotFoundException($"Task with id = {id} not found.");
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

        public async Task<IList<ProjectTask>> GetTasksByProject(int projectId, CancellationToken cancellationToken)
        {
            // If we use eager loading it returns cycle of project and tasks. I decided not to use eager loading for this method.
            var tasks = await _context.Tasks
                .Where(t => t.ProjectId == projectId)
                .ToListAsync(cancellationToken);

            if (!tasks.Any())
            {
                throw new NotFoundException("There are no tasks found");
            }

            return tasks;
        }

        public async Task UpdateTask(int taskId, string name, string description, int priority, int projectId,
            ProjectTaskStatus status, CancellationToken cancellationToken)
        {
            var task = await GetTaskById(taskId, cancellationToken);

            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId, cancellationToken);

            task.Name = name ?? task.Name;
            task.Description = description ?? task.Description;
            task.ProjectTaskStatus = status;
            task.Priority = priority;
            if (project != null)
            {
                task.ProjectId = project.Id;
            }

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteTask(int id, CancellationToken cancellationToken)
        {
            var task = await GetTaskById(id, cancellationToken);

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}