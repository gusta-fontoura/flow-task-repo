using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTask.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
       
        public List<Task> Tasks { get; set; } = new List<Task>();

        public Project() { }

        public Project(string name, string description, string author)
        {
            Name = name;
            Description = description;
            Author = author;
        }

        public Project(string name, string description)
        {
            Name = name;
            Description = description;
        }
            
    }
}
