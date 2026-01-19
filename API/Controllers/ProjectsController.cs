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
        public IActionResult GetAll()
        {
            var projects = _service.GetAll();
            return Ok(projects);
        }

        // 4. Método POST (Criar novo projeto)
        // Rota: POST api/projects
        [HttpPost]
        public IActionResult Post(CreateProjectInput model)
        {
            try
            {
                var project = _service.CreateProject(model);

                // Retorna status 201 (Created)
                return CreatedAtAction(nameof(GetAll), new { id = project.Id }, project);
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