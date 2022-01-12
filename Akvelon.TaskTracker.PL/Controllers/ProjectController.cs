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

        private readonly SortingAndFilteringService _serviceSortingAndFiltering;

        public ProjectController(ProjectService serviceProject, SortingAndFilteringService serviceSortingAndFiltering)
        {
            _serviceProject = serviceProject;
            _serviceSortingAndFiltering = serviceSortingAndFiltering;
        }
        
        // CRUD methods
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
        
        // Sorting methods
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/sort/startDate")]
        public async Task<IList<Project>> SortByStartDateDescending(CancellationToken cancellationToken)
        {
            var projects = await _serviceProject.GetAllProjects(cancellationToken);
            return _serviceSortingAndFiltering.SortByStartDateDescending(projects);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/sort/endDate")]
        public async Task<IList<Project>> SortByCompletionDateAscending(CancellationToken cancellationToken)
        {
            var projects = await _serviceProject.GetAllProjects(cancellationToken);
            return _serviceSortingAndFiltering.SortByCompletionDateAscending(projects);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/sort/priority")]
        public async Task<IList<Project>> SortByPriorityDescending(CancellationToken cancellationToken)
        {
            var projects = await _serviceProject.GetAllProjects(cancellationToken);
            return _serviceSortingAndFiltering.SortByPriorityDescending(projects);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/sort/status")]
        public async Task<IList<Project>> SortByStatusAscending(CancellationToken cancellationToken)
        {
            var projects = await _serviceProject.GetAllProjects(cancellationToken);
            return _serviceSortingAndFiltering.SortByStatusAscending(projects);
        }
        
        // Filtering methods
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/filter/startDate")]
        public async Task<IList<Project>> FilteringByStartDateAfter(DateTime dateAfter,
            CancellationToken cancellationToken)
        {
            var projects = await _serviceProject.GetAllProjects(cancellationToken);
            return _serviceSortingAndFiltering.FilteringByStartDateAfter(projects, dateAfter);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/filter/endDate")]
        public async Task<IList<Project>> FilteringByEndDateBefore(DateTime dateBefore,
            CancellationToken cancellationToken)
        {
            var projects = await _serviceProject.GetAllProjects(cancellationToken);
            return _serviceSortingAndFiltering.FilteringByEndDateBefore(projects, dateBefore);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/filter/countOfTasks")]
        public async Task<IList<Project>> FilteringCountOfTasksInRange(int start, int end,
            CancellationToken cancellationToken)
        {
            var projects = await _serviceProject.GetAllProjects(cancellationToken);
            return _serviceSortingAndFiltering.FilteringCountOfTasksInRange(projects, start, end);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/filter/status")]
        public async Task<IList<Project>> FilteringByProjectStatus(ProjectStatus status,
            CancellationToken cancellationToken)
        {
            var projects = await _serviceProject.GetAllProjects(cancellationToken);
            return _serviceSortingAndFiltering.FilteringByProjectStatus(projects, status);
        }
    }
}