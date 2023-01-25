using Microsoft.AspNetCore.Mvc;
using toDoList.API.Models;
using toDoList.API.Services;

namespace toDoList.API.Controllers
{
    [Route("api/Project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService service;
        public ProjectController(IProjectService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProjectDTO>>> GetAll()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetById([FromRoute] int id)
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
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateProject project)
        {
            var projectId = await service.AddAsync(project);
            return Created($"api/project/{projectId}", project);
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] ProjectDTO project)
        {
            await service.UpdateAsync(project);
            return Ok();
        }

        [HttpPatch("isDone/{id}")]
        public async Task<ActionResult> SetIsDone([FromRoute] int id)
        {
            var isAllDone = await service.IsAllToDosDoneAsync(id);
            if (isAllDone)
            {
                await service.SetIsDoneAsync(id);
                return Ok();
            }
            return BadRequest("Project must have at least one task and all must be completed!");
        }
    }
}
