using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Akvelon.TaskTracker.BLL.Services;
using Akvelon.TaskTracker.DAL.Entities;
using Akvelon.TaskTracker.DAL.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Akvelon.TaskTracker.PL.Controllers
{
    public class TaskController : ControllerBase
    {
        private readonly TaskService _service;

        public TaskController(TaskService service)
        {
            _service = service;
        }
        
        [HttpPost("task")]
        public async Task<int> CreateTask(string name, string description, int priority, int projectId, ProjectTaskStatus status,
            CancellationToken cancellationToken)
        {
            return await _service.CreateTask(name, description, priority, projectId, cancellationToken, status);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("tasks")]
        public async Task<IList<ProjectTask>> GetAllTasks(CancellationToken cancellationToken)
        {
            return await _service.GetAllTasks(cancellationToken);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("task")]
        public async Task<ProjectTask> GetTaskById(int id, CancellationToken cancellationToken)
        {
            return await _service.GetTaskById(id, cancellationToken);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("project/task")]
        public async Task<IList<ProjectTask>> GetTasksByProject(int projectId, CancellationToken cancellationToken)
        {
            return await _service.GetTasksByProject(projectId, cancellationToken);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("task")]
        public async Task UpdateTask(int taskId, string name, string description, int projectId, int priority,
            ProjectTaskStatus status,
            CancellationToken cancellationToken)
        {
            await _service.UpdateTask(taskId, name, description, priority, projectId, status, cancellationToken);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("task")]
        public async Task DeleteTask(int id, CancellationToken cancellationToken)
        {
            await _service.DeleteTask(id, cancellationToken);
        }
    }
}