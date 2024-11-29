using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApplication.Models
{
    public class UserRole
    {
        [Key]
        public int roleId { get; set; }
        public string roleName { get; set; }

        public virtual ICollection<User> users { get; set; }    
    }
}
