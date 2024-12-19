using Microsoft.AspNetCore.Mvc;
using TodoList_API.DTOs;
using TodoList_API.Services.Interface;

namespace TodoList_API.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

       [HttpPost("login")]
       public async Task<IActionResult> Login([FromBody]LoginDto loginDto)
        {
            var token = await _authService.AuthenticateAsync(loginDto.Username, loginDto.Password);
            if (token == null) return Unauthorized(new { message = "Invalid credentials provided." });
            
            return Ok(token);
        }
    }
}
