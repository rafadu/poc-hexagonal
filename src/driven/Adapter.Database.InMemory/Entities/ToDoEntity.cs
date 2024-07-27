
namespace Adapter.Database.InMemory.Entities
{
    public class ToDoEntity
    {
        public Guid Identification { get; set; }
        public string Title {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
        public DateTime CreatedAt {get; set;}
        public bool IsCompleted {get; set;}

        public Int64 Id {get; set;}
        public DateTime? FinishedAt {get; set;}
    }
}