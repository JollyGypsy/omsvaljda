using System.ComponentModel.DataAnnotations;

namespace WebAPI1.DTOs
{
    public class PhoneDTO
    {
        public int PhoneID { get; set; }
        [Required]
        public string PhoneValue { get; set; }
        public int CallCode { get; set; }
        [Required]
        public int ContactID { get; set; }
       
    }
}
