using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;
using toDoList.Models;

namespace toDoListWEB.Services
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public ProjectService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;

        }

        public List<Project> Projects { get; set; } = new List<Project>();

        public async Task AddAsync(Project project)
        {
            await _httpClient.PostAsJsonAsync($"api/project/", project);
            _navigationManager.NavigateTo("projects");
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/project/{id}");
            _navigationManager.NavigateTo("projects");
        }

        public async Task GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Project>>("api/project");

            Projects = result;
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            var result = await _httpClient.GetAsync($"api/project/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Project>();
            }
            return null;
        }

        public async Task UpdateAsync(int id, Project project)
        {
            await _httpClient.PutAsJsonAsync($"api/project/{id}", project);
            _navigationManager.NavigateTo("projects");
        }
    }
}
