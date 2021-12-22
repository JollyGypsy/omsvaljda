using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI1.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        [Required]
        public string AddressValue { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        [Required]
        public int ContactID { get; set; }

        [ForeignKey("ContactID")]
        public Contact ParentPerson { get; set; }

      
    }
}
