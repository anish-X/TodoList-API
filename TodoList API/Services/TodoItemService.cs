using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoList_API.DTOs;
using TodoList_API.Exceptions;
using TodoList_API.Models;
using TodoList_API.Repositories.Interface;
using TodoList_API.Services.Interface;

namespace TodoList_API.Services
{
    public class TodoItemService: ITodoItemService
    {
        private readonly ITodoItemRepository _repository;

        public TodoItemService(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodoItemAsync()
        {
            var todos = await _repository.GetAllItemAsync();
            if (todos == null)
                throw new NotFoundException("Couldn't retrieve the data");
            return todos;
        }

       
        public async Task<TodoItem> GetTodoItemAsync(int id)
        {
            var todo = await _repository.GetByIdAsync(id);
            if (todo == null)
                throw new CustomException("User not found!");
            return todo;
        }
        public async Task<TodoItem> CreateTodoAsync(TodoItemDto todoItemDto, string userId)
        {

            var TodoItem = new TodoItem
            {
                Title = todoItemDto.Title,
                Description = todoItemDto.Description,
                isCompleted = todoItemDto.IsCompleted,
                UserId = int.Parse(userId),

            };
            if (user == null)
                throw new CustomException("Data is not valid");
            return await _repository.CreateTodoAsync(TodoItem);
        }

        public async Task<TodoItem> UpdateTodoAsync(int id, TodoItemDto todoItemDto)
        {
            var todo = await _repository.GetByIdAsync(id);

            if (todo != null)
            {
                todo.Title = todoItemDto.Title;
                todo.Description = todoItemDto.Description;
            }
            else
            {
                throw new CustomException("Invalid Data");
            }
            return await _repository.UpdateTodoAsync(id);
        }

        public async Task<TodoItem> DeleteTodoItemAsync(int id)
        {
            var todo = await _repository.GetByIdAsync(id);
            if(todo != null)
            {
                throw new KeyNotFoundException($"user: {todo} not found");
            }
            var delete = await _repository.DeleteTodoAsync(id);
            return todo;
        }

        public async Task<TodoItem> SetStatusAsync(int id, bool isCompleted)
        {
            var todo = await _repository.GetByIdAsync(id);
            if (todo != null)
            {
                todo.isCompleted = isCompleted;

            }
            return await _repository.UpdateTodoAsync(id);

        }
    }
}
