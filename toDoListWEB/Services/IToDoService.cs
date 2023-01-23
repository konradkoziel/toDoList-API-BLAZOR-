using toDoList.Models;

namespace toDoListWEB.Services
{
    public interface IToDoService
    {
        List<ToDo> toDos { get; set; }
        Task GetAllAsync();
        Task GetAllByIdAsync(int id);
        Task<ToDo> GetByIdAsync(int projectid, int id);
        Task AddAsync(int id, ToDo toDo);
        Task UpdateAsync(int id, ToDo toDo);
        Task DeleteAsync(int id);
    }
}
