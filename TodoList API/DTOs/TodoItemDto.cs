namespace TodoList_API.DTOs
{
    public record TodoItemDto
    (
        int Id ,
        string Title,
        string Description,
        bool isCompleted

    );
}
