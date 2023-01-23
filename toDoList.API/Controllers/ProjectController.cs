using Microsoft.AspNetCore.Mvc;
using toDoList.API.Models;
using toDoList.API.Services;

namespace toDoList.API.Controllers
{
    [Route("api/project")]
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
            await service.DeleteAsync(id);
            return Accepted();
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateProject project)
        {
            var id = await service.AddAsync(project);

            return Created($"api/project/{id}", project);
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] ProjectDTO project)
        {
            var result = service.UpdateAsync(project);
            if (result == null) return NotFound();
            return Accepted();
        }
    }
}
