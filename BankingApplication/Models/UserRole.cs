using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
