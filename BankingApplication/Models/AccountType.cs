using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models
{
    public class AccountType
    {
        [Key]
        public int AccoutnTypeId { get; set; }
        [Required]
        public string AccountTypeName { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}
