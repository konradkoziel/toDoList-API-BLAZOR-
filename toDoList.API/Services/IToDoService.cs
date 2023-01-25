using toDoList.API.Entities;
using toDoList.API.Models;

namespace toDoList.API.Services
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDo>> GetAllAsync();
        Task<List<ToDo>> GetAllByProjectIdAsync(int id);
        Task<ToDo> GetByIdAsync(int id);
        Task<int> AddAsync(int id, CreateToDo createToDo);
        Task UpdateAsync(ToDoDTO ToDo);
        Task DeleteAsync(int id);
        Task SetIsDoneAsync(int id);
    }
}
