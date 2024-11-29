using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models
{
    public class Transaction
    {
        public int transactionId { get; set; }
        [Required]
        public int transactionTypeId { get; set; }
        [Required]
        public string fromUser { get; set; }
        [Required]
        public string toUser { get; set; }
        [Range(5000,100000)]

        public float amount { get; set; }
        [Required]
        public string remarks { get; set; }
        public string fromUserCurrentBalance { get; set; }
        public string toUserCurrentBalance { get; set; }
    }
}
