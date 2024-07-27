using Domain.Guards;

namespace Domain.Models
{
    public class TaskToDo
    {
        public Guid Id { get; private set; }
        public string Title {get; private set;}
        public string Description {get; private set;}
        public DateTime CreatedAt {get; private set;}
        public bool IsCompleted {get; private set;}

        public TaskToDo(Guid id, string title, string description, DateTime createdAt, bool isCompleted){
            CustomGuards.AgainstStringNullOrWhiteSpace(title, nameof(title));
            CustomGuards.AgainstStringNullOrWhiteSpace(description,nameof(description));
            Id = id;
            Title = title;
            Description = description;
            CreatedAt = createdAt;
            IsCompleted = isCompleted;
        }

        public TaskToDo(string title, string description)
            :this(Guid.NewGuid(),title,description,DateTime.Now,false)
        {}

        public void ChangeData(string title, string description, bool isCompleted){
            CustomGuards.AgainstStringNullOrWhiteSpace(title, nameof(title));
            CustomGuards.AgainstStringNullOrWhiteSpace(description,nameof(description));
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
        }

        public void FinishToDo(){
            IsCompleted = true;
        }
    }
}