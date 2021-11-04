namespace BankSystem
{
    public class CreditCard
    {
        private double _balance;
        private int _procent;
        
        
        public CreditCard(double stratBalance, int procent)
        {
            Balance = stratBalance;
            Procent = procent;
        }

        public int Procent
        {
            get => _procent;
            set => _procent = (value > 100 || value < 0) ? 0 : value;
        }

        public double Balance
        {
            get => _balance;
            set => _balance = (value < 0) ? 0 : value;
        }
    }
}