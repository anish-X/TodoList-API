using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList_API.DTOs;
using TodoList_API.Services.Interface;

namespace TodoList_API.Controllers
{
    [ApiController]
    [Route("api/user/[controller]")]
    public class TodoItemController : Controller
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet]
        [Authorize(Policy ="User")]
        public async Task<IActionResult> GetTodoItem()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
            var value = int.Parse(userId.Value);
            var todo = await _todoItemService.GetTodoItemAsync(value);
            return Ok(todo);
        }

        [HttpPost]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> CreateTodoAsync([FromBody]TodoItemDto todoItemDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return BadRequest("User ID claim not found.");
            }

            var value = userIdClaim.Value;
            await _todoItemService.CreateTodoAsync(todoItemDto, value);
            return Ok(todoItemDto);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> UpdateTodoAsync(int id, [FromBody]TodoItemDto todoItemDto)
        {
            var todo = await _todoItemService.GetTodoItemAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            var updated = await _todoItemService.UpdateTodoAsync(id, todoItemDto);
            return Ok(todoItemDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> DeleteTodoAsync(int id)
        {
            var todo = _todoItemService.GetTodoItemAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            var deleted = await _todoItemService.DeleteTodoItemAsync(id);
            return Ok(deleted);
        }

        [HttpPut("{id}/status")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> SetStatus(int id, bool isCompleted)
        {
            var todo = await _todoItemService.GetTodoItemAsync(id);
            if(todo == null)
            {
                return NotFound();
            }

            var status = await _todoItemService.SetStatusAsync(id, isCompleted);
            return Ok(status);
        }
    }

}
