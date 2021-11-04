namespace BankSystem
{
    public interface IAccount
    {
        public enum TypeOfAccount
        {
            Ordinary,
            Entrepreneur,
            VIP
        }
        
        public double Balance { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public void Add(double amount);
        public void Withdraw(double amount);
        public void TransferMoneyTo(IAccount otherAccount, double amount);
    }
}