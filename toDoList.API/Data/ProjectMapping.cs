using AutoMapper;
using toDoList.API.Entities;
using toDoList.API.Models;

namespace toDoList.API.Data
{
    public class ProjectMapping : Profile
    {
        public ProjectMapping()
        {
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();
            CreateMap<ToDo, ToDoDTO>();
            CreateMap<CreateProject, Project>();
            CreateMap<CreateToDo, ToDo>();

        }
    }
}
