using System.ComponentModel.DataAnnotations;

namespace ProjectMambaExam.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
