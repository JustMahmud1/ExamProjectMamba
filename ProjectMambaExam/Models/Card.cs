using System.ComponentModel.DataAnnotations;

namespace ProjectMambaExam.Models
{
    public class Card
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
