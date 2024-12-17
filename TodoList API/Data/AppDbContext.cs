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

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id); // Primary Key
                entity.HasIndex(u => u.Username).IsUnique(); // Unique constraint on Username
                entity.Property(u => u.Username).IsRequired(); // Username is required
            });

            modelBuilder.Entity<TodoItem>()
                .HasOne(u => u.User)
                .WithMany(t => t.TodoItems)
                .HasForeignKey(p => p.Username)
                .HasPrincipalKey(x => x.Username)
                .OnDelete(DeleteBehavior.Cascade); //Sdelete todo list if user is deleted
        }


    }
}
