using TodoList_API.DTOs;
using TodoList_API.Models;

namespace TodoList_API.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByUsernameAsync(string username);
        Task<User> CreateUserAsync(UserDto userDto);
        Task<User> UpdateUserAsync(string username, UserDto userDto);
        Task<bool> DeleteUserAsync(string username);
        Task<List<UserDto>> GetUserTodoAsync();
    }
}
