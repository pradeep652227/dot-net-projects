using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models
{
    public class User
    {
        [Key]//give primary key to a key of your choice usign [Key] attribute
        public int UserId { get; set; }
        [Required]

        public string UserName { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public int RoleId { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        public string AccountType { get; set; }

        [Range(5000,1000000)]
        public float CurrentBalance { get; set; } = 0.0F;
        public int BankId { get; set; }

    }
}
