using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;
using toDoList.Models;

namespace toDoListWEB.Services
{
    public class ToDoService : IToDoService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public ToDoService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;

        }

        public List<ToDo> toDos { get; set; } = new List<ToDo>();

        public async Task AddAsync(int id, ToDo ToDo)
        {
            await _httpClient.PostAsJsonAsync($"api/ToDo/{id}", ToDo);
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/ToDo/{id}");
        }

        public async Task GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ToDo>>("api/ToDo");

            toDos = result;
        }
        public async Task GetAllByIdAsync(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ToDo>>($"api/ToDo/{id}");

            toDos = result;
        }

        public async Task<ToDo> GetByIdAsync(int projectId, int id)
        {
            var result = await _httpClient.GetAsync($"api/ToDo/{projectId}/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<ToDo>();
            }
            return null;
        }

        public async Task UpdateAsync(int id, ToDo ToDo)
        {
            await _httpClient.PutAsJsonAsync($"api/ToDo/{id}", ToDo);

        }

        public async Task GetParameter(int id)
        {

        }


    }
}
