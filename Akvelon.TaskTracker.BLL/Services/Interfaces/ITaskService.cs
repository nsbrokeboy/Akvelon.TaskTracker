using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Akvelon.TaskTracker.DAL.Entities;
using Akvelon.TaskTracker.DAL.Enums;

namespace Akvelon.TaskTracker.BLL.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<int> CreateTask(string name, string description, int priority, int projectId,
            CancellationToken cancellationToken, ProjectTaskStatus status = ProjectTaskStatus.ToDo);

        public Task<ProjectTask> GetTaskById(int id, CancellationToken cancellationToken);

        public Task<IList<ProjectTask>> GetAllTasks(CancellationToken cancellationToken);

        public Task<IList<ProjectTask>> GetTasksByProject(int projectId, CancellationToken cancellationToken);

        public Task UpdateTask(int taskId, string name, string description, int priority, int projectId,
            ProjectTaskStatus status, CancellationToken cancellationToken);

        public Task DeleteTask(int id, CancellationToken cancellationToken);
    }
}