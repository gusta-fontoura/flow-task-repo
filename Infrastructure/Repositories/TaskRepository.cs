using FlowTask.Domain.Repositories;
using FlowTask.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskEntity = FlowTask.Domain.Entities.Task;


namespace FlowTask.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;
        public TaskRepository(AppDbContext context) 
        {
            _context = context;
        }

        public List<TaskEntity> GetAll()
        {
            return _context.Tasks.ToList();
        }


        public TaskEntity? GetById(int id)
        {
            return _context.Tasks.Find(id);
        }

        public void Add(TaskEntity task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Update(TaskEntity task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void Delete(TaskEntity task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}
