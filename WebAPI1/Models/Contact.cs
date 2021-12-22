using System.ComponentModel.DataAnnotations;

namespace WebAPI1.Models
{
    public class Contact
    { 
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
    }
}
