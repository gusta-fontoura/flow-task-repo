using FlowTask.API.Models;
using TaskEntity = FlowTask.Domain.Entities.Task;

namespace FlowTask.API.Services
{
    public interface ITaskService
    {
        List<TaskEntity> GetAll();
        TaskEntity Create(CreateTaskInput input);
        void Update(int id); 
        void Delete(int id);
    }
}
