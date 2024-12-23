﻿using TodoList_API.Services.Interface;
using TodoList_API.Models;
using TodoList_API.Repositories.Interface;
using TodoList_API.DTOs;
using Org.BouncyCastle.Security;
using TodoList_API.Exceptions;

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
            var users = await _userRepository.GetAllAsync();
            if (users == null)
                 throw new NotFoundException("Couldn't Fetch User Details");
            return users;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null)
                throw new CustomException("User not found!");
            return user;
        }

        public async Task<User> CreateUserAsync(UserDto userDto)
        {

            var HashPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Username = userDto.Username,
                Password = HashPassword,
                Role = userDto.Role
                //TodoItems = userDto.TodoItemDtos?.Select(t => new TodoItem
                //{
                //    Title = t.Title,
                //    Description = t.Description,
                //    isCompleted = t.IsCompleted
                //}).ToList() ?? new List<TodoItem>()
            };

            if (user == null)
                throw new CustomException("Data is not valid");
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
            else
            {
                throw new CustomException($"Invalid Data");
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

        public async Task<List<UserDto>> GetUserTodoAsync()
        {
            var users = await _userRepository.GetUserTodoAsync();
            if (users == null)
                throw new CustomException("Data is not valid");
            return users.Select(u => new UserDto
            {
                Name = u.Name,
                Email = u.Email,
                Role = u.Role,
                Username = u.Username,
                TodoItemDtos = u.TodoItems.Select(t => new TodoItemDto
                {
                    Title = t.Title,
                    Description = t.Description,
                    IsCompleted = t.isCompleted
                }).ToList()
            }).ToList();
        }

        
    }
}
