namespace TodoList_API.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool isCompleted { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; } = DateTime.UtcNow;

        //foreign key and navaigation of user
        public string? Username { get; set; }
        public User? User { get; set; }

    }
}
