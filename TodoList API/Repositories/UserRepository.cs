﻿using Microsoft.EntityFrameworkCore;
using TodoList_API.Data;
using TodoList_API.Exceptions;
using TodoList_API.Models;
using TodoList_API.Repositories.Interface;
namespace TodoList_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var user = await _context.Users.ToListAsync();
            if(user == null) 
                throw new RepositoryException("Couldn't retrieve data");
            return user;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
                throw new RepositoryException("Couldn't retrieve data");
            return user;
        }

        public async Task<User> CreateAsync(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving user: {ex.Message}");
                throw;
            }
            
        }

        public async Task<User> UpdateByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);   

            if (user != null) {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            } else {
                if (user == null)
                    throw new RepositoryException("Couldn't retrieve data");
                return false;
            }
        }

        public async Task<List<User>> GetUserTodoAsync()
        {
            return await _context.Users
                .Include(u => u.TodoItems)
                .ToListAsync();
        }

    }
}
