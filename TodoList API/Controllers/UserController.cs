using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList_API.DTOs;
using TodoList_API.Services.Interface;

namespace TodoList_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITodoItemService _todoItemService;
        public UserController(IUserService userService, ITodoItemService todoItemService)
        {
            _userService = userService;
            _todoItemService = todoItemService;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{username}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetByUsernameAsync(string username)
        {
            var user = await _userService.GetByUsernameAsync(username);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserDto userDto)
        {
            
            await _userService.CreateUserAsync(userDto);
            return Ok(userDto);
        }

        [HttpPut("{username}")]
        public async Task<IActionResult> UpdateUserAsync(string username, [FromBody] UserDto userDto)
        {
            var exisitingUser = await _userService.GetByUsernameAsync(username);
            if (exisitingUser == null)
            {
                return NotFound();
            }

            var updated = await _userService.UpdateUserAsync(username, userDto);
            return Ok(updated);

        }

        [HttpDelete]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteUserAsync(string username)
        {
            var user = await _userService.GetByUsernameAsync($"{username}");
            if(user == null)
            {
                return NotFound();
            }

            var deleted = await _userService.DeleteUserAsync(username);
            return Ok(deleted);
        }

        [HttpGet("users-with-todos")]
        public async Task<IActionResult> GetUsersWithTodos()
        {
            var usersWithTodos = await _userService.GetUserTodoAsync();
            return Ok(usersWithTodos);
        }


    }
}
