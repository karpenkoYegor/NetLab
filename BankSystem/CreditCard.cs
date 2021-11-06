using System;

namespace BankSystem
{
    public class CreditCard
    {
        private double _balanceWithProcent;
        private double _balance;
        private int _procent;
        
        public CreditCard(double stratBalance, int procent)
        {
            Balance = stratBalance;
            Procent = procent;
            _balanceWithProcent = Balance * (1 + Procent / 100);
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

        public double BalanceWithProcent
        {
            get => _balanceWithProcent;
            
        }

        public double WithdrawCreditCard(double amount)
        {
            if (Balance < amount)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            return amount;
        }
        
        public void Replenishment(double amount)
        {
            if (amount > 0)
            {
                _balance += amount;
            }
        }
    }
}