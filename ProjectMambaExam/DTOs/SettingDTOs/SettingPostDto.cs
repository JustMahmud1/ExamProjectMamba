using System.ComponentModel.DataAnnotations;

namespace ProjectMambaExam.DTOs.SettingDTOs
{
    public class SettingPostDto
    {
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
