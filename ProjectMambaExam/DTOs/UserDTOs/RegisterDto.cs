using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectMambaExam.DTOs.UserDTOs
{
    public class RegisterDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
