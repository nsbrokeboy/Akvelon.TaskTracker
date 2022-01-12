using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Akvelon.TaskTracker.DAL.Entities;
using Akvelon.TaskTracker.DAL.Enums;

namespace Akvelon.TaskTracker.BLL.Services.Interfaces
{
    public interface IProjectService
    {
        public Task<int> CreateProject(string name, DateTime startDate, DateTime endDate,
            CancellationToken cancellationToken,
            ProjectStatus status = ProjectStatus.NotStarted,
            int priority = 1);

        public Task<Project> GetProjectById(int id, CancellationToken cancellationToken);

        public Task<IList<Project>> GetAllProjects(CancellationToken cancellationToken);

        public Task UpdateProject(int projectId, string name, DateTime startDate, DateTime endDate,
            ProjectStatus status, int priority, CancellationToken cancellationToken);

        public Task DeleteProject(int id, CancellationToken cancellationToken);
    }
}