using AutoMapper;
using Microsoft.EntityFrameworkCore;
using toDoList.API.Data;
using toDoList.API.Entities;
using toDoList.API.Models;

namespace toDoList.API.Services
{
    public class ToDoService : IToDoService
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ToDoService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<int> AddAsync(int id, CreateToDo createToDo)
        {
            var toDo = mapper.Map<ToDo>(createToDo);
            var project = await context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            toDo.ProjectId = id;
            toDo.Project = project;
            await context.AddAsync(toDo);
            context.SaveChangesAsync();
            return toDo.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await context.ToDos.FindAsync(id);
            context.Remove(result);
            context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToDo>> GetAllAsync()
        {
            var result = await context.ToDos.ToListAsync();
            return result;
        }

        public async Task<List<ToDo>> GetAllByIdAsync(int id)
        {
            var result = await context.ToDos.Where(p => p.ProjectId == id).ToListAsync();
            return result;
        }
        public async Task<ToDo> GetByIdAsync(int projectId, int id)
        {
            var result = await context.ToDos.FindAsync(id);
            return result;
        }

        public async Task<ToDoDTO> UpdateAsync(int id, ToDoDTO toDoDTO)
        {
            var toDo = await context.ToDos.FindAsync(id);
            if (toDo != null)
            {
                toDo.Name = toDoDTO.Name;
                toDo.Description = toDoDTO.Description;
                toDo.IsDone = toDoDTO.IsDone;

                await context.SaveChangesAsync();
            }

            return toDoDTO;
        }
    }
}
