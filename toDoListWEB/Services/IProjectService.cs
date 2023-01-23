using toDoList.Models;

namespace toDoListWEB.Services
{
    public interface IProjectService
    {
        List<Project> Projects { get; set; }
        Task GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(Project project);
        Task UpdateAsync(int id, Project project);
        Task DeleteAsync(int id);
    }
}
