using System.ComponentModel.DataAnnotations;

namespace ProjectMambaExam.DTOs.UserDTOs
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
