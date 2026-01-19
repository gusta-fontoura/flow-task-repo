using FlowTask.API.Models;
using FlowTask.API.Services;
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

        public TaskEntity Create(CreateTaskInput input) 
        {
            if (string.IsNullOrEmpty(input.Title))
            {
                throw new Exception("O título da tarefa é obrigatório");
            }

            var task = new TaskEntity(input.Title, input.Description, input.ProjectId);

            _repository.Add(task);

            return task;
        }

        public void Update(int id)
        {
            var task = _repository.GetById(id);
            if (task == null)
            {
                throw new Exception("Tarefa não encontrada.");
            }

            task.IsCompleted = true;
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
