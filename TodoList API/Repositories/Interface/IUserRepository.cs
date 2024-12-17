using TodoList_API.Models;

namespace TodoList_API.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByUsernameAsync(string username);
        Task<User> CreateAsync(User user);
        Task<User> UpdateByUsernameAsync(string username);
        Task<bool> DeleteByUsernameAsync(string username);

     }     
}