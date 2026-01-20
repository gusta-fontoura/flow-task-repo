using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowTask.Domain.Entities;
using FlowTask.Domain.Repositories;
using FlowTask.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace FlowTask.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Project> GetAll()
        {
            return _context.Projects
                .Include(p => p.Tasks)
                .ToList();
        }

        public Project? GetById(int id)
        {
            return _context.Projects
                .Include (p => p.Tasks)
                .FirstOrDefault(p => p.Id == id);
        }
        public void Add(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void Delete(Project project)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
        public void Update(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }
    }
}
