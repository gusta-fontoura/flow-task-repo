using FlowTask.Domain.Entities;

namespace FlowTask.API.Models
{
    public class UpdateTaskInput
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskEntityStatus Status { get; set; }
    }
}
