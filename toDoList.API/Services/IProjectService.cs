using toDoList.API.Models;

namespace toDoList.API.Services
{
    public interface IProjectService
    {
        Task<List<ProjectDTO>> GetAllAsync();
        Task<ProjectDTO> GetByIdAsync(int id);
        Task<int> AddAsync(CreateProject project);
        Task UpdateAsync(ProjectDTO project);
        Task DeleteAsync(int id);
    }
}
