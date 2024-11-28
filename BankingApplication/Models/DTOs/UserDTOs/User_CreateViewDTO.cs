using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models.DTOs.UserDTOs
{
    public class User_CreateViewDTO
    {
        public User? user { get; set; }

        public Address? userAddress { get; set; }
        //[Display(Name = "User Name")]
        //public string UserName { get; set; }
        //[Required]

        //[Display(Name = "First Name")]
        //public string FirstName { get; set; }
        //[Required]

        //[Display(Name = "Last Name")]
        //public string LastName { get; set; }

        //[Required]
        //[Display(Name = "Role")]
        //public int RoleId { get; set; }
        //[Required]

        //public string Email { get; set; }
        //[Required]

        //public string Password { get; set; }
        //[Required]

        //[Display(Name = "Account Type")]
        //public int AccountType { get; set; }

        //[Display(Name = "Bank")]

        //public int BankId { get; set; }

        //[Required]
        //[DisplayName("City")]
        //public string city { get; set; }
        //[Required]
        //[DisplayName("Landmark")]
        //public string landMark { get; set; }
        //[Required]
        //[DisplayName("Pin Code")]
        //public string pinCode { get; set; }
        //[Required]
        //[DisplayName("State")]
        //public string state { get; set; }
        //[Required]
        //[DisplayName("Address")]
        //public string address { get; set; }

    }
}
