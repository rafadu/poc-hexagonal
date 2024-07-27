using Domain.Models;

namespace Domain.Ports.Driven
{
    public interface IAdapterDatabasePortService
    {
        Task<bool> InsertToDo(TaskToDo newTaskToDo);
        Task<bool> ChangeToDo(TaskToDo toDoToChange);        
        Task<bool> DeleteToDo(Guid id);
        Task<IEnumerable<TaskToDo>> GetAll();
        Task<TaskToDo> GetById(Guid id);
    }
}