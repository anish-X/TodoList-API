using Microsoft.EntityFrameworkCore;
using TodoList_API.Models;

namespace TodoList_API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public required DbSet<User> Users { get; set; }

        public DbSet<TodoItem>? TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       
            modelBuilder.Entity<User>()
                .HasMany(u => u.TodoItems)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade); //Sdelete todo list if user is deleted
               
        }


    }
}
