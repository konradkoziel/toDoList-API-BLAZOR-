using Microsoft.AspNetCore.Mvc;
using toDoList.API.Entities;
using toDoList.API.Models;
using toDoList.API.Services;

namespace toDoList.API.Controllers
{
    [Route($"api/ToDos")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService service;
        public ToDoController(IToDoService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetAll()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("Project/{projectId}")]
        public async Task<ActionResult<List<ToDoDTO>>> GetAllByProjectId([FromRoute] int projectId)
        {
            var result = await service.GetAllByProjectIdAsync(projectId);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoDTO>> GetById([FromRoute] int id)
        {
            var result = await service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById([FromRoute] int id)
        {
            var result = await service.GetByIdAsync(id);
            if (result == null) return NotFound();
            await service.DeleteAsync(id);
            return Accepted(id);
        }
        [HttpPost("{projectId}")]
        public async Task<ActionResult> Add([FromRoute] int projectId, [FromBody] CreateToDo createToDo)
        {
            var toDoId = await service.AddAsync(projectId, createToDo);
            return Created($"api/ToDo/{toDoId}", createToDo);
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] ToDoDTO ToDo)
        {
            if (ToDo == null) return BadRequest();
            await service.UpdateAsync(ToDo);
            return Accepted($"api/ToDo/", ToDo);
        }

        [HttpPatch("isDone/{id}")]
        public async Task<ActionResult> SetIsDone([FromRoute] int id)
        {
            var toDo = await service.GetByIdAsync(id);
            if (toDo == null) return NotFound();
            await service.SetIsDoneAsync(id);
            return Ok();
        }
    }
}
