using System;
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
    public class ProjectService : IProjectService
    {
        private readonly TaskTrackerDbContext _context;

        public ProjectService(TaskTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateProject(string name, DateTime startDate, DateTime endDate,
            CancellationToken cancellationToken,
            ProjectStatus status = ProjectStatus.NotStarted,
            int priority = 1)
        {
            var project = new Project
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Priority = priority,
                Status = status
            };

            await _context.Projects.AddAsync(project, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return project.Id;
        }

        public async Task<Project> GetProjectById(int id, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.Include(p => p.Tasks)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (project == null)
            {
                throw new NotFoundException($"Project with id = {id} not found.");
            }

            return project;
        }

        public async Task<IList<Project>> GetAllProjects(CancellationToken cancellationToken)
        {
            var projects = await _context.Projects.Include(p => p.Tasks).ToListAsync(cancellationToken);
            if (!projects.Any())
            {
                throw new NotFoundException("There are no projects found");
            }

            return projects;
        }

        public async Task UpdateProject(int projectId, string name, DateTime startDate, DateTime endDate,
            ProjectStatus status, int priority, CancellationToken cancellationToken)
        {
            var project = await GetProjectById(projectId, cancellationToken);

            project.Name = name ?? project.Name;
            project.StartDate = startDate;
            project.EndDate = endDate;
            project.Priority = priority;
            project.Status = status;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteProject(int id, CancellationToken cancellationToken)
        {
            var project = await GetProjectById(id, cancellationToken);

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}