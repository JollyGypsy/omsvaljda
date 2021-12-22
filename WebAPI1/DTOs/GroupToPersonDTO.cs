using System.ComponentModel.DataAnnotations;

namespace WebAPI1.DTOs
{
    public class GroupToPersonDTO
    {
        public int ID { get; set; }
        [Required]
        public int ContactID { get; set; }
        [Required]
        public int GroupID { get; set; }

    }
}
