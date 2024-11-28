using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models
{
    public class Address
    {
        [Key]
        public int addressId { get; set; }
        public int userId { get; set; }
        public string city { get; set; }
        public string landMark { get; set; }
        public string pinCode { get; set; }
        public string state { get; set; }
        public string address { get; set; }
    }
}
