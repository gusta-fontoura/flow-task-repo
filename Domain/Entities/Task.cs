using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowTask.Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TaskEntityStatus Status { get; set; }
        public int ProjectId { get; set; }
        public ETaskPriority Priority { get; set; }
        public Project? Project { get; set; }
        public Task() { }
        public Task(string title, string description, int projectId) 
        {
            Title = title;
            Description = description; 
            ProjectId = projectId;
            Status = TaskEntityStatus.ToDo;
            Priority = ETaskPriority.Low;
            DueDate = DateTime.Now.AddDays(7);

            
        }

        public void Update(string title, string description, TaskEntityStatus status, ETaskPriority priority)
        {
            Title = title;
            Description = description;
            Status = status;
            Priority = priority;
        }

        public void UpdateStatus(TaskEntityStatus status)
        {
            Status = status;
        }

    }
}
