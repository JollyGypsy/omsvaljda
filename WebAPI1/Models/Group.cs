using System.ComponentModel.DataAnnotations;

namespace WebAPI1.Models
{
    public class Group
    {
        [Key]
        public int GroupID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
