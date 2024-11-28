using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BankingApplication.Helpers.Enums;

namespace BankingApplication.Models
{
    public class User
    {
        [Key]//give primary key to a key of your choice usign [Key] attribute
        public int UserId { get; set; }
        [Required]

        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Role")]
        public int RoleId { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        [Display(Name = "Account Type")]
        public int AccountType { get; set; }


        [Display(Name = "Current Balance")]
        public float? CurrentBalance { get; set; } = 0.0F;

        [Display(Name = "Bank")]

        public int BankId { get; set; }

        public int AddressId { get; set; }

        public DateTime AccountCreatedOn { get; set; } = DateTime.UtcNow;

        public string AccountStatus { get; set; } = (UserAccountStatus.PendingActivation).ToString();

        public DateTime PaymentUpdatedOn { get; set; } = DateTime.UtcNow;

        [ForeignKey("RoleId")]
        public virtual UserRole? Role { get; set; }

        [ForeignKey("BankId")]
        public virtual Bank? Bank { get; set; }

        [ForeignKey("AccountType")]
        public virtual AccountType? UserAccount { get; set; }

        public virtual int? Address { get; set; }

    }
}
