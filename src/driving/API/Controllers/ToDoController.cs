using Domain.DTOs;
using Domain.Ports.Driving;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController(IApiPortService apiPortService) : ControllerBase
    {
        private readonly IApiPortService apiPortService = apiPortService;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewToDo newToDo){
            var result = await apiPortService.InsertNewToDo(newToDo);

            if(result.IsSuccess()){
                return Ok();
            }

            if(result.HasException()){
                return StatusCode(StatusCodes.Status500InternalServerError,new{message=result.Message});
            }

            return BadRequest(new {message=result.Message});
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute]Guid id, [FromBody]ChangingToDo changingToDo){
            var result = await apiPortService.ChangeToDo(id,changingToDo);

            if(result.IsSuccess()){
                return Ok();
            }

            if(result.HasException()){
                return StatusCode(StatusCodes.Status500InternalServerError,new{message=result.Message});
            }

            return BadRequest(new {message=result.Message});
        }

        [HttpPut]
        [Route("conclude-todo/{id:guid}")]
        public async Task<IActionResult> PutToCompleteToDo([FromRoute]Guid id){
            var result = await apiPortService.FinishToDo(id);

            if(result.IsSuccess()){
                return Ok();
            }

            if(result.HasException()){
                return StatusCode(StatusCodes.Status500InternalServerError,new{message=result.Message});
            }

            return BadRequest(new {message=result.Message});
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id){
            var result = await apiPortService.DeleteToDo(id);

            if(result.IsSuccess()){
                return Ok();
            }

            if(result.HasException()){
                return StatusCode(StatusCodes.Status500InternalServerError,new{message=result.Message});
            }

            return BadRequest(new {message=result.Message});
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var result = await apiPortService.GetAllToDo();

            if(result.IsSuccess()){
                return Ok(result.Data);
            }

            if(result.HasException()){
                return StatusCode(StatusCodes.Status500InternalServerError,new{message=result.Message});
            }

            return BadRequest(new {message=result.Message});
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id){
            var result = await apiPortService.GetToDoById(id);

            if(result.IsSuccess()){
                return Ok(result.Data);
            }

            if(result.HasException()){
                return StatusCode(StatusCodes.Status500InternalServerError,new{message=result.Message});
            }

            return BadRequest(new {message=result.Message});
        }
    }
}