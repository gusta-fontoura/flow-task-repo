using FlowTask.API.Models;
using TaskEntity = FlowTask.Domain.Entities.Task;
using FlowTask.Domain.Entities;

namespace FlowTask.API.Services
{
    public interface ITaskService
    {
        List<TaskEntity> GetAll();
        TaskEntity Create(CreateTaskInput input);
        void Delete(int id);
        TaskEntity GetById (int id);
        void UpdateStatus(int id, TaskEntityStatus status);
        void Update(int id, string title, string description, TaskEntityStatus status, ETaskPriority priority);
    }
}
