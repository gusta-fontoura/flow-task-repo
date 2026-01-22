using Microsoft.AspNetCore.Mvc;
using FlowTask.Domain.Entities;          // Importando suas entidades
using FlowTask.Infrastructure.Persistence; // Importando o DbContext
using Microsoft.EntityFrameworkCore;
using FlowTask.API.Services;
using FlowTask.API.Models;     // Necessário para métodos assíncronos (se usarmos no futuro)

namespace FlowTask.API.Controllers
{
    [Route("api/[controller]")] // Define a rota como: https://localhost:xxxx/api/projects
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        // 1. O campo privado para armazenar a conexão com o banco
        private readonly IProjectService _service;

        // 2. O Construtor: A API injeta o banco aqui automaticamente
        public ProjectsController(IProjectService service)
        {
            _service = service;
        }

        // 3. Método GET (Listar todos os projetos)
        // Rota: GET api/projects
        [HttpGet]
        public IActionResult Get()
        {
            var projects = _service.GetAll();

            var viewModel = projects.Select(ProjectViewModel.FromEntity);

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _service.GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(ProjectViewModel.FromEntity(project));
        }

        // 4. Método POST (Criar novo projeto)
        // Rota: POST api/projects
        [HttpPost]
        public IActionResult Post(CreateProjectInput model)
        {
            try
            {
                var project = _service.CreateProject(model);

                var viewModel = ProjectViewModel.FromEntity(project);

                return CreatedAtAction(nameof(Get), new { id = project.Id }, viewModel);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);            
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeleteProject(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}