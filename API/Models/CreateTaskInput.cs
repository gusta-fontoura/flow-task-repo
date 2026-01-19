namespace FlowTask.API.Models
{
    public class CreateTaskInput
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; } // O elo de ligação
    }
}