using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Akvelon.TaskTracker.BLL.Services;
using Akvelon.TaskTracker.DAL.Entities;
using Akvelon.TaskTracker.DAL.Enums;
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

        [HttpPost("taskCreate")]
        public async Task<int> CreateTask(string name, string description, int priority, ProjectTaskStatus status,
            CancellationToken cancellationToken)
        {
            return await _service.CreateTask(name, description, priority, cancellationToken, status);
        }

        [HttpGet("tasks")]
        public async Task<IList<ProjectTask>> GetAllTasks(CancellationToken cancellationToken)
        {
            return await _service.GetAllTasks(cancellationToken);
        }

        [HttpGet("task")]
        public async Task<ProjectTask> GetTaskById(int id, CancellationToken cancellationToken)
        {
            return await _service.GetTaskById(id, cancellationToken);
        }

        [HttpPut("taskUpdate")]
        public async Task UpdateTask(int taskId, string name, string description, int priority,
            ProjectTaskStatus status,
            CancellationToken cancellationToken)
        {
            await _service.UpdateTask(taskId, name, description, priority, status, cancellationToken);
        }

        [HttpDelete("taskDelete")]
        public async Task DeleteTask(int id, CancellationToken cancellationToken)
        {
            await _service.DeleteTask(id, cancellationToken);
        }
    }
}