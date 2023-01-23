using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using toDoListWEB;
using toDoListWEB.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7053") });
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IToDoService, ToDoService>();
await builder.Build().RunAsync();
