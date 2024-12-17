namespace TodoList_API.DTOs
{
    public record UserDto
    (
        int Id ,
        string? Name,
        string? Email,
        string? Username,
        string? Role,
        List<TodoItemDto> TodoItemDtos
    );
}
