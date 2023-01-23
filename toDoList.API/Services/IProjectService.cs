using toDoList.API.Models;

namespace toDoList.API.Services
{
    public interface IProjectService
    {
        Task<List<ProjectDTO>> GetAllAsync();
        Task<ProjectDTO> GetByIdAsync(int id);
        Task<int> AddAsync(ProjectDTO project);
        Task<ProjectDTO> UpdateAsync(ProjectDTO project);
        Task DeleteAsync(int id);
    }
}
