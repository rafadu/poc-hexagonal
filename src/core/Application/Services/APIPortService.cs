using Domain.Common;
using Domain.DTOs;
using Domain.Models;
using Domain.Ports.Driven;
using Domain.Ports.Driving;

namespace Application.Services
{
    public class ApiPortService : IApiPortService
    {
        private readonly IAdapterDatabasePortService adapterDatabasePortService;
        public ApiPortService(IAdapterDatabasePortService adapterDatabasePortService){
            this.adapterDatabasePortService = adapterDatabasePortService;
        }

        public async Task<Result<bool>> ChangeToDo(Guid id, ChangingToDo taskToDo)
        {
            try{
                var existingToDo = await adapterDatabasePortService.GetById(id);
            
                if(existingToDo is null)
                    return new Result<bool>($"ToDo with ID {id} Not founded",true);

                existingToDo.ChangeData(taskToDo.Title,taskToDo.Description,taskToDo.IsCompleted);
            
                var result = await adapterDatabasePortService.ChangeToDo(existingToDo);
            
                return new Result<bool>(result);
            }
            catch(ArgumentException ex){
                return new Result<bool>(ex.Message,true);
            }
            catch(Exception ex){
                return new Result<bool>(ex);
            }
        }

        public async Task<Result<bool>> DeleteToDo(Guid id)
        {
            try{
                var existingToDo = await adapterDatabasePortService.GetById(id);
            
                if(existingToDo is null)
                    return new Result<bool>($"ToDo with ID {id} Not founded",true);

                var result = await adapterDatabasePortService.DeleteToDo(id);

                return new Result<bool>(result);
            }
            catch(ArgumentException ex){
                return new Result<bool>(ex.Message,true);
            }
            catch(Exception ex){
                return new Result<bool>(ex);
            }
        }

        public async Task<Result<bool>> FinishToDo(Guid id)
        {
            try{
                var existingToDo = await adapterDatabasePortService.GetById(id);
            
                if(existingToDo is null)
                    return new Result<bool>($"ToDo with ID {id} Not founded",true);

                existingToDo.FinishToDo();

                var result = await adapterDatabasePortService.ChangeToDo(existingToDo);

                return new Result<bool>(result);
            }
            catch(ArgumentException ex){
                return new Result<bool>(ex.Message,true);
            }
            catch(Exception ex){
                return new Result<bool>(ex);
            }
        }

        public async Task<Result<IEnumerable<ReturnToDo>>> GetAllToDo()
        {
            try{
                var list = await adapterDatabasePortService.GetAll();
                var result = list.Select(l => ReturnToDo.FromTaskToDo(l));
                return new Result<IEnumerable<ReturnToDo>>(result);
            }
            catch(ArgumentException ex){
                return new Result<IEnumerable<ReturnToDo>>(ex.Message,true);
            }
            catch(Exception ex){
                return new Result<IEnumerable<ReturnToDo>>(ex);
            }
        }

        public async Task<Result<ReturnToDo>> GetToDoById(Guid id)
        {
            try{
                var toDo = await adapterDatabasePortService.GetById(id);
                if(toDo is null)
                    return new Result<ReturnToDo>($"ToDo with ID {id} Not Founded.",true);
                var result = ReturnToDo.FromTaskToDo(toDo);
                return new Result<ReturnToDo>(result);
            }
            catch(ArgumentException ex){
                return new Result<ReturnToDo>(ex.Message,true);
            }
            catch(Exception ex){
                return new Result<ReturnToDo>(ex);
            }
        }

        public async Task<Result<bool>> InsertNewToDo(NewToDo taskToDo)
        {
            try{
                var newToDo = new TaskToDo(taskToDo.Title,taskToDo.Description);
                var result = await adapterDatabasePortService.InsertToDo(newToDo);
                return new Result<bool>(result);
            }
            catch(ArgumentException ex){
                return new Result<bool>(ex.Message,true);
            }
            catch(Exception ex){
                return new Result<bool>(ex);
            }
        }
    }
}