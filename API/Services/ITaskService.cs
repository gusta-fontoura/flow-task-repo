using FlowTask.API.Models;
using FlowTask.Domain.Entities;
using System.Security.Cryptography;
using TaskEntity = FlowTask.Domain.Entities.Task;

namespace FlowTask.API.Services
{
    public interface ITaskService
    {
        List<TaskEntity> GetAll();
        TaskEntity Create(CreateTaskInput input);
        void Delete(int id);
        TaskEntity GetById (int id);
        void UpdateStatus(int id, TaskEntityStatus status);
        void UpdatePriority(int id, ETaskPriority priority);
        void Update(int id, string title, string description, TaskEntityStatus status, ETaskPriority priority);
    }
}
