namespace BankingApplication.Models
{
    public class Bank
    {
        public int BankId { get; set; }

        public string BankName { get; set; }
        public string City { get; set; }
        public string LandMark { get; set; }
        public string PINCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
