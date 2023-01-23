using Microsoft.AspNetCore.Mvc;
using toDoList.API.Entities;
using toDoList.API.Models;
using toDoList.API.Services;

namespace toDoList.API.Controllers
{
    [Route($"api/toDo")]
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

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ToDoDTO>>> GetAllByprojectId([FromRoute] int id)
        {
            var result = await service.GetAllByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpGet("{projectId}/{id}")]
        public async Task<ActionResult<ToDoDTO>> GetById([FromRoute] int id, [FromRoute] int projectId)
        {
            var result = await service.GetByIdAsync(projectId, id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById([FromRoute] int id)
        {
            await service.DeleteAsync(id);
            return Accepted(id);
        }
        [HttpPost("{id}")]
        public async Task<ActionResult> Add([FromRoute] int id, [FromBody] CreateToDo createToDo)
        {
            var toDoId = await service.AddAsync(id, createToDo);
            return Created($"api/ToDo/{toDoId}", createToDo);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] ToDoDTO ToDo)
        {
            var result = service.UpdateAsync(id, ToDo);
            if (result == null) return NotFound();
            return Accepted($"api/ToDo/", ToDo);
        }
    }
}
