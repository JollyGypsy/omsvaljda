using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI1.Models
{
    public class GroupToPerson
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ContactID { get; set; }
        [Required]
        public int GroupID { get; set; }
        

        [ForeignKey("ContactID")]
        public Contact  ParentContact { get; set; }

        [ForeignKey("GroupID")]
        public Group ParentGroup { get; set; }
    }
}
