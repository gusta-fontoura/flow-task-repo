using FlowTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTask.Domain.Repositories
{
    public interface IProjectRepository
    {
        List<Project> GetAll();
        Project? GetById(int id);
        void Add(Project project);
        void Update(Project project);
        void Delete(Project project);
    }
}
