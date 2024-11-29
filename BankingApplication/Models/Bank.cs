namespace BankingApplication.Models
{
    public class Bank
    {
        public int bankId { get; set; }

        public string bankName { get; set; }
        public string city { get; set; }
        public string landMark { get; set; }
        public string pinCode { get; set; }
        public string state { get; set; }
        public string country { get; set; }

        public virtual ICollection<User> users { get; set; }
    }
}
