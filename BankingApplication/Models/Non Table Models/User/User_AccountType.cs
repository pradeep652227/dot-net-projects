using System.ComponentModel;

namespace BankingApplication.Models.Non_Table_Models.Users
{
    public class User_AccountType
    {
        public User user { get; set; }

        [DisplayName("Account Type")]
        public string accountType { get; set; }

        [DisplayName("User Bank")]
        public string userBank { get; set; }

        [DisplayName("Role")]
        public string userRole { get; set; }
    }
}
