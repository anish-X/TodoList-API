namespace TodoList_API.DTOs
{
    public record UserDto
    (
        string? Name,
        string? Email,
        string? Username,
        string Password,
        string? Role
    );
}
