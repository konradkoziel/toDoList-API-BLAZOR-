using Microsoft.EntityFrameworkCore;
using toDoList.API.Entities;

namespace toDoList.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Project>(e =>
            {
                e.HasMany(c => c.ToDoList)
                .WithOne(c => c.Project)
                .HasForeignKey(c => c.ProjectId);
            });
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
    }
}

