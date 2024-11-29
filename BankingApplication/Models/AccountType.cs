using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models
{
    public class AccountType
    {
        [Key]
        public int accountTypeId { get; set; }
        [Required]
        public string accountTypeName { get; set; }

        public virtual ICollection<User> users { get; set; }

    }
}
