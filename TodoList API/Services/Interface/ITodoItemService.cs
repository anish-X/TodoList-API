using TodoList_API.DTOs;
using TodoList_API.Models;

namespace TodoList_API.Services.Interface
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetAllTodoItemAsync();
        Task<TodoItem> GetTodoItemAsync(int id);
        Task<TodoItem> CreateTodoAsync(TodoItemDto todoItemDto,string userId);
        Task<TodoItem> UpdateTodoAsync(int id, TodoItemDto todoItemDto);
        Task<TodoItem> DeleteTodoItemAsync(int id);
        Task<TodoItem> SetStatusAsync(int id, bool isCompleted);

    }
}
