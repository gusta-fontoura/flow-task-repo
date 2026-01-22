using FlowTask.API.Models;
using FlowTask.API.Services;
using FlowTask.Domain.Entities;
using FlowTask.Domain.Repositories;
using TaskEntity = FlowTask.Domain.Entities.Task;


namespace FLowTask.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }


        public List<TaskEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TaskEntity? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public TaskEntity Create(CreateTaskInput input) 
        {
            if (string.IsNullOrEmpty(input.Title))
            {
                throw new Exception("O título da tarefa é obrigatório");
            }

            var task = new TaskEntity(input.Title, input.Description, input.ProjectId);

            task.Priority = input.Priority;

            _repository.Add(task);

            return task;
        }

        public void Update(int id, string title, string description, TaskEntityStatus status, ETaskPriority priority)
        {
            var task = _repository.GetById(id);
            if (task == null)
            {
                throw new Exception("Tarefa não encontrada.");
            }

            task.Update(title, description, status, priority);

            _repository.Update(task);
        }

        public void UpdateStatus(int id, TaskEntityStatus status)
        {
            var task = _repository.GetById(id);
            if (task == null)
            {
                throw new Exception("Tarefa não encontrada.");
            }

            task.Status = status;

            task.UpdateStatus(status);

            _repository.Update(task);
        }

        public void UpdatePriority(int id, ETaskPriority priority)
        {
            var task = _repository.GetById(id);
            if (task == null)
            {
                throw new Exception("Tarefa não encontrada.");
            }

            task.Priority = priority;

            _repository.Update(task);
        }

        public void Delete(int id)
        {
            var task = _repository.GetById(id);

            if (task == null)
            {
                throw new Exception("Tarefa não encontrada.");
            }

            _repository.Delete(task);
        }
    }
}
