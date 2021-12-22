using System.ComponentModel.DataAnnotations;

namespace WebAPI1.DTOs
{
    public class AddressDTO
    {
        public int AddressID { get; set; }
        [Required]
        public string AddressValue { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public int ContactID { get; set; }
    }
}
