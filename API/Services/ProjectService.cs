using FlowTask.Domain.Entities;
using FlowTask.Infrastructure.Persistence;
using FlowTask.API.Models;
using FlowTask.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlowTask.API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository) 
        {
            _repository = repository;   
        }

        public Project CreateProject(CreateProjectInput input)
        {
            var projectExists = _repository.GetAll().FirstOrDefault(p =>  p.Name == input.Name);
            if (projectExists != null)
            {
                throw new Exception("Já existe um projeto com este nome.");
            }

            if (string.IsNullOrEmpty(input.Description))
            {
                input.Description = "Projeto sem descrição definida";
            }

            var project = new Project(input.Name, input.Description, input.Author);

            _repository.Add(project);

            return project;
        }

        public List<Project> GetAll()
        {
            return _repository.GetAll();
        }

        public void DeleteProject(int id)
        {

            var project = _repository.GetById(id);

            if (project == null)
            {
               throw new Exception($"Projeto com ID {id} não encontrado no banco.");
            }

            _repository.Delete(project);
        }
    }
}
