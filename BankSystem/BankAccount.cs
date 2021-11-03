using System;

namespace BankSystem
{
    public class BankAccount : IAccount
    {
        public enum TypeOfAccount
        {
            Ordinary,
            Entrepreneur,
            VIP
        }

        private double _balance;
        private TypeOfAccount _typeOfAccount;
        private double _maxWithdrawar = 500;
        private string _ssnNumber;
        public string _firstName;
        public string _lastName;

        public double Balance
        {
            get
            {
                return _balance;
            }
        }
        public string FirstName
        {
            get {
                return (char.IsUpper(_firstName[0]))
                    ? _firstName
                    : char.ToUpper(_firstName[0]) + _firstName.Substring(1);
            }
            set
            {
                _firstName = char.ToUpper(value[0]) + value.Substring(1);
            }
        }
        public string LastName
        {
            get
            {
                return (char.IsUpper(_lastName[0]))
                    ? _lastName
                    : char.ToUpper(_lastName[0]) + _lastName.Substring(1);
            }
            set
            {
                _lastName = char.ToUpper(value[0]) + value.Substring(1);
            }
        }

        public BankAccount(string firstName, string lastName, double balance, TypeOfAccount typeOfAccount)
        {
            _balance = balance;
            _typeOfAccount = typeOfAccount;
            FirstName = firstName;
            LastName = lastName;
        }

        public void Add(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            _balance += amount;
        }

        public void TransferMoneyTo(IAccount otherAccount, double amount)
        {
            if (otherAccount is null)
            {
                throw new NullReferenceException(nameof(amount));
            }

            Withdraw(amount);
            otherAccount.Add(amount);
        }

        public void Withdraw(double amount)
        {
            if (_balance < amount)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            if (_typeOfAccount == TypeOfAccount.Ordinary && amount > 500)
            {
                amount = _maxWithdrawar;
            }
            _balance -= amount;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"First name - {FirstName}");
            Console.WriteLine($"Last name - {LastName}");
            Console.WriteLine($"Balance - {Balance}");
            Console.WriteLine($"SSN number - {_ssnNumber}");
        }
    }
}
