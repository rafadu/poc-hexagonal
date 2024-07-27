using System.Collections.Concurrent;
using Adapter.Database.InMemory.Entities;
using Domain.Models;
using Domain.Ports.Driven;

namespace Adapter.Database.InMemory.Repositories
{
    public class ToDoRepository : IAdapterDatabasePortService
    {
        private readonly ConcurrentDictionary<int,ToDoEntity> Database;

        private Func<KeyValuePair<int,ToDoEntity>,bool> GetPredicate(Guid id){
            return (KeyValuePair<int,ToDoEntity> kvp) 
                => kvp.Value.Identification == id;
        }

        public ToDoRepository(){
            Database = new ConcurrentDictionary<int,ToDoEntity>();
        }

        public async Task<bool> ChangeToDo(TaskToDo toDoToChange)
        {
            if(!Database.Any(GetPredicate(toDoToChange.Id)))
                return false;
            
            var kvp = Database.First(d => d.Value.Identification == toDoToChange.Id);

            kvp.Value.Description = toDoToChange.Description;
            kvp.Value.FinishedAt = toDoToChange.IsCompleted?DateTime.Now:null!;
            kvp.Value.IsCompleted = toDoToChange.IsCompleted;
            kvp.Value.Title = toDoToChange.Title;
            
            await Task.FromResult(0);
            return true;
        }

        public async Task<bool> DeleteToDo(Guid id)
        {
            if(!Database.Any(GetPredicate(id)))
                return false;

            var kvp = Database.First(GetPredicate(id));

            Database.Remove(kvp.Key,out _);
            await Task.FromResult(0);
            return true;
        }

        public async Task<IEnumerable<TaskToDo>> GetAll()
        {
            var list = Database.Select(kvp => new TaskToDo(
                kvp.Value.Identification,
                kvp.Value.Title,
                kvp.Value.Description,
                kvp.Value.CreatedAt,
                kvp.Value.IsCompleted
            ));
            await Task.FromResult(0);
            return list;
        }

        public async Task<TaskToDo> GetById(Guid id)
        {            
            var kvp = Database.FirstOrDefault(GetPredicate(id));

            if(kvp.Value is null)
                return null!;

            await Task.FromResult(0);
            return new TaskToDo(kvp.Value.Identification,
                                kvp.Value.Title,
                                kvp.Value.Description,
                                kvp.Value.CreatedAt,
                                kvp.Value.IsCompleted);
        }

        public async Task<bool> InsertToDo(TaskToDo newTaskToDo)
        {
            var id = Database.Count+1;
            var entity = new ToDoEntity{
                CreatedAt = newTaskToDo.CreatedAt,
                Description = newTaskToDo.Description,
                FinishedAt = null!,
                Id = id,
                Identification = newTaskToDo.Id,
                IsCompleted = false,
                Title = newTaskToDo.Title
            };
            Database.TryAdd(id,entity);
            await Task.FromResult(0);
            return true;
        }
    }
}