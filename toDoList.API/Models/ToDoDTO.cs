namespace toDoList.API.Models
{
    public class ToDoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public int ProjectId { get; set; }
    }
}
