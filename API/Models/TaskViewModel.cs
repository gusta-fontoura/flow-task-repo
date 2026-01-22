using TaskEntity = FlowTask.Domain.Entities.Task;

namespace FlowTask.API.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }  
        public string Priority { get; set; } 
        public int ProjectId { get; set; }

        public static TaskViewModel FromEntity(TaskEntity task)
        {
            return new TaskViewModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Status = task.Status.ToString(),
                Priority = task.Priority.ToString(),
                ProjectId = task.ProjectId
            };
        }

    }
}
