using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        [Required]
        public int TransactionTypeId { get; set; }
        [Required]
        public string FromUser { get; set; }
        [Required]
        public string ToUser { get; set; }
        [Range(5000,100000)]

        public float Amount { get; set; }
        [Required]
        public string Remarks { get; set; }
        public string FromUserCurrentBalance { get; set; }
        public string ToUserCurrentBalance { get; set; }
    }
}
