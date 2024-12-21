using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoList_API.Models
{
    public class User
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50,ErrorMessage = "Should not be more than 50")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [EmailAddress(ErrorMessage = "Invalid Email.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required(ErrorMessage = "Select Role")]
        public string Role { get; set; } 
        public bool isActive { get; set; }   
        public DateTime? CreatedAt{ get; set; }

        //navigation property for the todo list
        public ICollection<TodoItem> TodoItems { get; set; }   

    }

    
    
}
