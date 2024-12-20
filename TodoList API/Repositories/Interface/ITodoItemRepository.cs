using TodoList_API.Models;

namespace TodoList_API.Repositories.Interface
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<TodoItem>> GetAllItemAsync();
        Task<TodoItem> GetByIdAsync(int id);
        Task<TodoItem> CreateTodoAsync(TodoItem item);
        Task<TodoItem> UpdateTodoAsync(int index);
        Task<bool> DeleteTodoAsync(int index);
        Task<IEnumerable<TodoItem>> GetTodoItemsByUserIdAsync(string userId);
    }
}
