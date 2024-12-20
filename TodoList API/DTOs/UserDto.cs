using TodoList_API.Models;

namespace TodoList_API.DTOs
{
    public class UserDto
    {
        public string Name  { get; set; }
        public string Email {  get; set; }
        public string Username { get; set; }    
        public string Password { get; set; }
        public string Role { get; set; }
        public List<TodoItemDto> TodoItemDtos { get; set; }
    }
}
