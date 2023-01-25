using AutoMapper;
using Microsoft.EntityFrameworkCore;
using toDoList.API.Data;
using toDoList.API.Entities;
using toDoList.API.Models;

namespace toDoList.API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public ProjectService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<int> AddAsync(CreateProject project)
        {
            var result = mapper.Map<Project>(project);
            await context.AddAsync(result);
            await context.SaveChangesAsync();
            return result.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await context.Projects.FindAsync(id);
            context.Remove(result);
            await context.SaveChangesAsync();
        }

        public async Task<List<ProjectDTO>> GetAllAsync()
        {
            var projects = await context.Projects.ToListAsync();
            var result = mapper.Map<List<ProjectDTO>>(projects);
            return result;
        }

        public async Task<ProjectDTO> GetByIdAsync(int id)
        {
            var project = await context.Projects.FindAsync(id);
            var result = mapper.Map<ProjectDTO>(project);
            return result;
        }

        public async Task UpdateAsync(ProjectDTO projectDTO)
        {
            var project = mapper.Map<Project>(projectDTO);
            context.Update(project);
            await context.SaveChangesAsync();
        }

        public async Task<bool> IsAllToDosDoneAsync(int id)
        {
            var project = await context.Projects.FindAsync(id);
            var toDos = await context.ToDos.Where(x => x.ProjectId == id).ToListAsync();
            if (project != null && toDos.Any() && toDos.All(x => x.IsDone == true))
            {
                return true;
            }
            else return false;
        }

        public async Task SetIsDoneAsync(int id)
        {
            var project = await context.Projects.FindAsync(id);
            project.IsDone = true;
            await context.SaveChangesAsync();

        }
    }
}
