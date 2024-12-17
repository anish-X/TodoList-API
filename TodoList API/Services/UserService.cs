using TodoList_API.Services.Interface;
using TodoList_API.Models;
using TodoList_API.Repositories.Interface;
using TodoList_API.DTOs;

namespace TodoList_API.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }

        public async Task<User> CreateUserAsync(UserDto userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
                Username = userDto.Username,
                Role = userDto.Role ?? "User",             
            };

            return await _userRepository.CreateAsync(user);
        }

        public async Task<User> UpdateUserAsync(string username, UserDto userDto)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(username);
            if (existingUser != null)
            {
                existingUser.Email = userDto.Email;
                existingUser.Role = userDto.Role ?? "User";
                existingUser.Name = userDto.Name;
            }
            return await _userRepository.UpdateByUsernameAsync(username);
          
        }

        public async Task<bool> DeleteUserAsync(string username) {

            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null)
            {
                throw new KeyNotFoundException($"user: {username} not found");
            }
            var deleted = await _userRepository.DeleteByUsernameAsync(username);
            if (!deleted)
            {
                return false;
            }
            else { return true; }
        }
        
    }
}
