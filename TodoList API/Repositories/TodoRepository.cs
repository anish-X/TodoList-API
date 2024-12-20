using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TodoList_API.Data;
using TodoList_API.Models;
using TodoList_API.Repositories.Interface;

namespace TodoList_API.Repositories
{
    public class TodoRepository: ITodoItemRepository
    {
        private readonly AppDbContext _context;

        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAllItemAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> CreateTodoAsync(TodoItem todoItem)
        {
            try
            {
                _context.TodoItems.Add(todoItem);
                await _context.SaveChangesAsync();
                return todoItem;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<TodoItem> UpdateTodoAsync(int index)
        {
            var todo = await _context.TodoItems.FirstOrDefaultAsync(t => t.Id == index);
            _context.TodoItems.Update(todo);
            await _context.SaveChangesAsync();
            return todo;


        }

        public async Task<bool> DeleteTodoAsync(int index)
        {
            var todo = await _context.TodoItems.FirstOrDefaultAsync(t => t.Id == index);
            if (todo != null)
            {
                _context.TodoItems.Remove(todo);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<TodoItem> GetByIdAsync(int id)
        {
            var todo = await _context.TodoItems.FirstOrDefaultAsync(t => t.Id == id);
            return todo;
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItemsByUserIdAsync(string userId)
        {
            return await _context.TodoItems
                                 .Where(t => t.UserId == int.Parse(userId))  // Filter by UserId
                                 .ToListAsync();
        }

    }
}
