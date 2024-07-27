using Domain.Models;

namespace Domain.DTOs
{
    public class ReturnToDo
    {
        public string Id {get; set;} = string.Empty;
        public string Title {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
        public DateTime CreatedAt {get; set;}
        public bool IsCompleted {get; set;}

        public static ReturnToDo FromTaskToDo(TaskToDo taskToDo)
            => new()
            {
                Id = taskToDo.Id.ToString(),
                Title = taskToDo.Title,
                Description = taskToDo.Description,
                CreatedAt = taskToDo.CreatedAt,
                IsCompleted = taskToDo.IsCompleted
            };
    }
}