using System.ComponentModel.DataAnnotations;

namespace toDoList.API.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<ToDo> ToDoList { get; set; }
    }
}
