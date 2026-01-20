using FlowTask.Domain.Entities;
using FlowTask.API.Models;

namespace FlowTask.API.Services
{
    public interface IProjectService
    {
        Project CreateProject(CreateProjectInput input);
        List<Project> GetAll();
        void DeleteProject(int id);
        Project GetById(int id);
    }
}
