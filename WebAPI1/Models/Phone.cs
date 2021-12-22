using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI1.Models
{
    public class Phone
    {
        [Key]
        public int PhoneID { get; set; }
        [Required]
        public string PhoneValue { get; set; }
        public int CallCode { get; set; }
        public int ContactID { get; set; }
        [Required]

        [ForeignKey("ContactID")]
        public Contact ParentPerson { get; set; }
    }
}
