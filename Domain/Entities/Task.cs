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
        public bool IsCompleted { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public Task() { }
        public Task(string title, string description, int projectId) 
        {
            Title = title;
            Description = description; 
            ProjectId = projectId;
            IsCompleted = false;
            DueDate = DateTime.Now.AddDays(7);
        }

    }
}
