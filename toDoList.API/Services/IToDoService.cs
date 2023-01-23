using toDoList.API.Entities;
using toDoList.API.Models;

namespace toDoList.API.Services
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDo>> GetAllAsync();
        Task<List<ToDo>> GetAllByIdAsync(int id);
        Task<ToDo> GetByIdAsync(int projectId, int id);
        Task<int> AddAsync(int id, CreateToDo createToDo);
        Task<ToDoDTO> UpdateAsync(int id, ToDoDTO ToDo);
        Task DeleteAsync(int id);
    }
}
