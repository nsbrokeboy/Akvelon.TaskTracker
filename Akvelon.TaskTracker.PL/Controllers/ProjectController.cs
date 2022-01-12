using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Akvelon.TaskTracker.BLL.Services;
using Akvelon.TaskTracker.BLL.Services.Implementations;
using Akvelon.TaskTracker.DAL.Entities;
using Akvelon.TaskTracker.DAL.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Akvelon.TaskTracker.PL.Controllers
{
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _serviceProject;


        public ProjectController(ProjectService serviceProject)
        {
            _serviceProject = serviceProject;
        }

        [HttpPost("project")]
        public async Task<int> CreateProject(string name, DateTime startDate, DateTime endDate,
            int priority, ProjectStatus status, CancellationToken cancellationToken)
        {
            return await _serviceProject.CreateProject(name, startDate, endDate, cancellationToken, status, priority);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("project")]
        public async Task<Project> GetProjectById(int id, CancellationToken cancellationToken)
        {
            return await _serviceProject.GetProjectById(id, cancellationToken);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects")]
        public async Task<IList<Project>> GetAllProjects(CancellationToken cancellationToken)
        {
            return await _serviceProject.GetAllProjects(cancellationToken);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("project")]
        public async Task UpdateProject(int projectId, string name, DateTime startDate, DateTime endDate,
            ProjectStatus status, int priority, CancellationToken cancellationToken)
        {
            await _serviceProject.UpdateProject(projectId, name, startDate, endDate, status, priority,
                cancellationToken);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("project")]
        public async Task DeleteProject(int id, CancellationToken cancellationToken)
        {
            await _serviceProject.DeleteProject(id, cancellationToken);
        }
    }
}