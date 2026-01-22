using FlowTask.Domain.Entities;

namespace FlowTask.API.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalTasks { get; set; }

        public static ProjectViewModel FromEntity(Project project)
        {
            return new ProjectViewModel
            {
                Id = project.Id,
                Name = project.Name,
                TotalTasks = project.Tasks?.Count ?? 0
            };
        }
    }
}
