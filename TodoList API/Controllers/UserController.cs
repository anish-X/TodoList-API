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

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUsernameAsync(string username)
        {
            var user = await _userService.GetByUsernameAsync(username);
            return Ok(user);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]

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
    }
}
