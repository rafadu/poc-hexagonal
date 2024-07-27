using Domain.Common;
using Domain.DTOs;

namespace Domain.Ports.Driving
{
    public interface IApiPortService
    {
        Task<Result<bool>> InsertNewToDo(NewToDo taskToDo);
        Task<Result<bool>> ChangeToDo(Guid id, ChangingToDo taskToDo);
        Task<Result<bool>> DeleteToDo(Guid id);
        Task<Result<bool>> FinishToDo(Guid id);
        Task<Result<IEnumerable<ReturnToDo>>> GetAllToDo();
        Task<Result<ReturnToDo>> GetToDoById(Guid id);
    }
}