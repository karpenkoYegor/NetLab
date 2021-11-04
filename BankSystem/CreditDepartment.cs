using System;

namespace BankSystem
{
    public static class CreditDepartment
    {
        public static CreditCard PermissionToIssueACard(BankAccount _account)
        {
            if (_account.Balance <= 200)
            {
                return CardIssuance(_account);
            }
            else
            {
                Console.WriteLine("Not allowed");
                return null;
            }
        }
        public static CreditCard CardIssuance(BankAccount _account)
        {
            double _startBalance = 0;
            int _procent = 0;
            switch (_account.Account)
            {
                case BankAccount.TypeOfAccount.Ordinary:
                    _procent = 25;
                    _startBalance = 1000;
                    break;
                case BankAccount.TypeOfAccount.Entrepreneur:
                    _procent = 20;
                    _startBalance = 2000;
                    break;
                case BankAccount.TypeOfAccount.VIP:
                    _procent = 10;
                    _startBalance = 5000;
                    break;
            }

            return new CreditCard(_startBalance, _procent);
        }
    }
}