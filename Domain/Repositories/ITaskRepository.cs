using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskEntity = FlowTask.Domain.Entities.Task;

namespace FlowTask.Domain.Repositories
{
    public interface ITaskRepository
    {
        TaskEntity? GetById(int id);
        void Delete(TaskEntity task);
        List<TaskEntity> GetAll();
        void Add(TaskEntity task);
        void Update(TaskEntity task);
    }
}
