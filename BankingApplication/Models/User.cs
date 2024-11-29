using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BankingApplication.Helpers.Enums;

namespace BankingApplication.Models
{
    public class User
    {
        [Key]//give primary key to a key of your choice usign [Key] attribute
        public int userId { get; set; }
        [Required]

        [Display(Name = "User Name")]
        public string userName { get; set; }
        [Required]

        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required]

        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "Role")]
        public int roleId { get; set; }
        [Required]

        public string email { get; set; }
        [Required]

        public string password { get; set; }
        [Required]

        [Display(Name = "Account Type")]
        public int accountType { get; set; }


        [Display(Name = "Current Balance")]
        public float? currentBalance { get; set; } = 0.0F;

        [Display(Name = "Bank")]

        public int bankId { get; set; }

        public int addressId { get; set; }

        public DateTime accountCreatedOn { get; set; } = DateTime.UtcNow;

        public string accountStatus { get; set; } = (UserAccountStatus.PendingActivation).ToString();

        public DateTime paymentUpdatedOn { get; set; } = DateTime.UtcNow;


        public virtual UserRole? Role { get; set; }

 
        public virtual Bank? Bank { get; set; }


        public virtual AccountType? UserAccount { get; set; }

        public virtual Address? Address { get; set; }

    }
}
