using System.ComponentModel.DataAnnotations;

namespace MvCProj_1.Models.Authentication
{
    public class UserLoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
