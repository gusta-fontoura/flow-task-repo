using FlowTask.API.Models;
using FlowTask.API.Services;
using FlowTask.Domain.Entities;
using FlowTask.Domain.Repositories;
using FlowTask.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
                var viewModel = TaskViewModel.FromEntity(task);

                return CreatedAtAction(nameof(GetAll), new { id = task.Id }, viewModel);
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

            var viewModels = tasks.Select(TaskViewModel.FromEntity);
            

            return Ok(viewModels);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var task = _service.GetById(id);

            if (task == null)
            {
                return NotFound();
            }

            var viewModel = TaskViewModel.FromEntity(task);

            return Ok();
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

        [HttpPatch("{id}/priority")]
        public IActionResult UpdatePriority(int id, [FromBody] UpdateTaskInput input)
        {
            if (!Enum.IsDefined(typeof(ETaskPriority), input.Priority))
            {
                return BadRequest("Prioridade inválido.");
            }

            _service.UpdatePriority(id, input.Priority);

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