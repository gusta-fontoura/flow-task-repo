using FlowTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class UpdateTaskStatusInput
    {
        public TaskEntityStatus Status { get; set; }
    }
}
