using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models
{
    public class Address
    {
        [Key]
        public int addressId { get; set; }
        public int? userId { get; set; }
        [Required]
        [DisplayName("City")]
        public string city { get; set; }
        [Required]
        [DisplayName("Landmark")]
        public string landMark { get; set; }
        [Required]
        [DisplayName("Pin Code")]
        public string pinCode { get; set; }
        [Required]
        [DisplayName("State")]
        public string state { get; set; }
        [Required]
        [DisplayName("Address")]
        public string address { get; set; }

        public ICollection<User>? users { get; set; }    
    }
}
