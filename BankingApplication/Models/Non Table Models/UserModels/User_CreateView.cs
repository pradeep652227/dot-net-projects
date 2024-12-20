﻿namespace BankingApplication.Models.Non_Table_Models.Users
{
    public class User_CreateView
    {
        public User user { get; set; }
        public IEnumerable<Bank> banks { get; set; }
        public IEnumerable<AccountType> accountTypes { get; set; }
        public IEnumerable<UserRole> userRoles { get; set; }
        public Address userAddress { get; set; }
    }
}
