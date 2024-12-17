namespace TodoList_API.Models
{
    public class User
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? salt { get; set; }
        public string Role { get; set; } = "default";
        public bool isActive { get; set; }   
        public DateTime? CreatedAt{ get; set; }

        //navigation property for the todo list
        public ICollection<TodoItem>? TodoItems { get; set; }   

    }
}
