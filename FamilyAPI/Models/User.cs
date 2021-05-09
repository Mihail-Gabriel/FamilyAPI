using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Required, Key]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}