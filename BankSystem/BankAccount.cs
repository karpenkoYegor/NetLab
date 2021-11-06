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
        public TypeOfAccount Account;
        private double _maxWithdrawar = 500;
        private string _ssnNumber;
        private string _firstName;
        private string _lastName;

        private string _logMessage;
        
        public CreditCard Card { get; private set; } = null;
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
            Account = typeOfAccount;
            FirstName = firstName;
            LastName = lastName;
            _ssnNumber =
                $"{new Random().Next(100, 999)} - {new Random().Next(10, 99)} - {new Random().Next(1000, 9999)}";
        }

        public void Add(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            _balance += amount;
            _logMessage += $"User {FirstName} {LastName} {_ssnNumber} added {amount}$ balance equal {Balance}\n";
        }

        public void TransferMoneyTo(IAccount otherAccount, double amount)
        {
            if (otherAccount is null)
            {
                throw new NullReferenceException(nameof(amount));
            }
            
            Withdraw(amount);
            otherAccount.Add(amount);
            _logMessage += $"User {FirstName} {LastName} {_ssnNumber} transfer {amount}$ to {otherAccount.FirstName} {otherAccount.LastName} balance equal {Balance}\n";
        }

        public void Withdraw(double amount)
        {
            if (_balance < amount)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            if (Account == TypeOfAccount.Ordinary && amount > _maxWithdrawar)
            {
                amount = _maxWithdrawar;
            }
            _balance -= amount;
            _logMessage += $"User {FirstName} {LastName} {_ssnNumber} withdraw {amount}$ balance equal {Balance}\n";
        }

        public void WithdrawCreditCrad(double amount)
        {
            Card.WithdrawCreditCard(amount);
            _logMessage += $"User {FirstName} {LastName} {_ssnNumber} withdraw {amount}$ from credit card balance equal {Card.Balance}\n";
        }

        public void TakeACredit()
        {
            if (Card is null)
            {
                Card = CreditDepartment.PermissionToIssueACard(this);
                _logMessage += $"User {FirstName} {LastName} {_ssnNumber} take a credit\n";
            }
        }

        public void CloseACredit()
        {
            if (!CreditDepartment.CloseACredit(Card))
            {
                throw new Exception($"Replenishment balance to {Card.BalanceWithProcent} now {Card.Balance}");
            }
            Card = null;
            _logMessage += $"User {FirstName} {LastName} {_ssnNumber} close a credit\n";
        }
        public void ShowInfo()
        {
            Console.WriteLine($"First name - {FirstName}");
            Console.WriteLine($"Last name - {LastName}");
            Console.WriteLine($"Balance - {Balance}");
            Console.WriteLine($"SSN number - {_ssnNumber}");
            Logger.Log(_logMessage);
        }
    }
}
