using System.ComponentModel.DataAnnotations;

namespace school_helper.DTOs
{
    public class UserDTO
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
