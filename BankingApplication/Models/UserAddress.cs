using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models
{
    public class UserAddress
    {
        [Key]
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public string LandMark { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
    }
}
