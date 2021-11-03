namespace BankSystem
{
    public interface IAccount
    {
        enum TypeOfAccount
        {
            Base,
            Business,
            VIP
        }
        
        public double Balance { get; }
        public void Add(double amount);
        public void Withdraw(double amount);
        public void TransferMoneyTo(IAccount otherAccount, double amount);
    }
}