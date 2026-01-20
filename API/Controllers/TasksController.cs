using Microsoft.AspNetCore.Mvc;
using FlowTask.Domain.Entities;
using FlowTask.Infrastructure.Persistence;
using FlowTask.API.Models;
using FlowTask.Domain.Repositories;
using FlowTask.API.Services;

namespace FlowTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        // POST api/tasks
        [HttpPost]
        public IActionResult Post(CreateTaskInput model)
        {
            try
            {
                var task = _service.Create(model);
                return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/tasks
        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = _service.GetAll();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var tasks = _service.GetById(id);

            if (tasks == null)
            {
                return NotFound();
            }

            return Ok(tasks);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateTaskInput input)
        {
            try
            {
                _service.Update(id, input.Title, input.Description, input.Status, ETaskPriority.Low);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new {message = ex.Message});
            }
        }

        [HttpPatch("{id}/status")]
        public IActionResult UpdateStatus(int id, [FromBody] UpdateTaskInput input)
        {
            if (!Enum.IsDefined(typeof(TaskEntityStatus), input.Status))
            {
                return BadRequest("Status inválido.");
            }

            _service.UpdateStatus(id, input.Status);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}