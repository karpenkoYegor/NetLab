using System;
using Xunit;

namespace BankSystem.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Withdraw_ValidAmount_ChageBalance()
        {
            double currentBalance = 10.0;
            double withdrawal = 1.0;
            double expected = 9.0;
            var account = new BankAccount("Yegor", "Karpenko",currentBalance, BankAccount.TypeOfAccount.Ordinary);

            account.Withdraw(withdrawal);

            Assert.Equal(expected, account.Balance);

        }
        [Fact]
        public void Withdraw_OrdinaryAccount_ChageBalance()
        {
            double currentBalance = 1000.0;
            double withdrawal = 600.0;
            double expected = 500.0;
            var account = new BankAccount("Yegor", "Karpenko", currentBalance, BankAccount.TypeOfAccount.Ordinary);

            account.Withdraw(withdrawal);

            Assert.Equal(expected, account.Balance);

        }
        [Fact]
        public void Withdraw_WithdrawalMoreCurrentBalance_ChageBalance()
        {
            double currentBalance = 500.0;
            double withdrawal = 600.0;
            var account = new BankAccount("Yegor", "Karpenko", currentBalance, BankAccount.TypeOfAccount.Ordinary);

            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(withdrawal));

        }
        [Fact]
        public void Withdraw_VIPAccount_ChageBalance()
        {
            double currentBalance = 1000.0;
            double withdrawal = 600.0;
            double expected = 400.0;
            var account = new BankAccount("Yegor", "Karpenko", currentBalance, BankAccount.TypeOfAccount.VIP);

            account.Withdraw(withdrawal);

            Assert.Equal(expected, account.Balance);
        }

        [Fact]
        public void Adding_ValidAmount_ChangeBalance()
        {
            double currentBalance = 9.0;
            double adding = 1.0;
            double expected = 10.0;
            var account = new BankAccount("Yegor", "Karpenko", currentBalance, BankAccount.TypeOfAccount.Ordinary);

            account.Add(adding);

            Assert.Equal(expected, account.Balance);
        }
        [Fact]
        public void Adding_InvalidAmount_ChangeBalance()
        {
            double currentBalance = 9.0;
            double adding = 0;
            double expected = 10.0;
            var account = new BankAccount("Yegor", "Karpenko", currentBalance, BankAccount.TypeOfAccount.Ordinary);


            Assert.Throws<ArgumentOutOfRangeException>(() => account.Add(adding));
        }
        [Fact]
        public void TransferMoneyTo_ValidAmount_ChangeBothAccount()
        {
            double currentBalanceFirstAccount = 9.0;
            double currentBalanceSecondAccount = 10.0;
            double expectedFirstAccountBalance = 4.0;
            double expectedSecondAccountBalance = 15.0;
            var account = new BankAccount("Yegor", "Karpenko", currentBalanceFirstAccount, BankAccount.TypeOfAccount.Ordinary);
            var otherAccount = new BankAccount("Yegor", "Karpenko", currentBalanceSecondAccount, BankAccount.TypeOfAccount.Ordinary);

            account.TransferMoneyTo(otherAccount, 5);

            Assert.Equal(expectedFirstAccountBalance, account.Balance);
            Assert.Equal(expectedSecondAccountBalance, otherAccount.Balance);
        }
        [Fact]
        public void TransferMoneyTo_NullAccount_ChangeBothAccount()
        {
            double currentBalance = 9.0;
            double adding = 1.0;
            double expected = 10.0;
            BankAccount account = new BankAccount("Yegor", "Karpenko", currentBalance, BankAccount.TypeOfAccount.Ordinary);
            BankAccount otherAccount = null;

            Assert.Throws<NullReferenceException>(() => account.TransferMoneyTo(otherAccount, 5));
        }

        [Fact]
        public void ShowInfo_InformatoinAboutAccount_Information()
        {
            double currentBalance = 9.0;
            double adding = 1.0;
            double expected = 10.0;
            BankAccount account = new BankAccount("Yegor", "Karpenko", currentBalance, BankAccount.TypeOfAccount.Ordinary);

            account.ShowInfo();
        }
        [Fact]
        public void TakeACredit_CreditCardIsNotNull_InicializeCard()
        {
            double currentBalance = 10.0;
            BankAccount account = new BankAccount("Yegor", "Karpenko", currentBalance, BankAccount.TypeOfAccount.Ordinary);
            account.TakeACredit();

            var expected = account.Card;
            
            Assert.NotEqual(expected, null);
        }
        [Fact]
        public void TakeACredit_CurrentBalanceMoreThan200_InicializeCard()
        {
            double currentBalance = 500.0;
            BankAccount account = new BankAccount("Yegor", "Karpenko", currentBalance, BankAccount.TypeOfAccount.Ordinary);
            account.TakeACredit();

            CreditCard expected = null;
            
            Assert.Equal(expected, account.Card);
        }

        [Fact]
        public void CloseACredit_ReturnTrue_CurrentBalanceWithProcent()
        {
            double currentBalance = 10.0;
            BankAccount account = new BankAccount("Yegor", "Karpenko", currentBalance, BankAccount.TypeOfAccount.Ordinary);
            account.TakeACredit();
            account.Add(1500);
            account.WithdrawCreditCrad(400);
            account.Card.Replenishment(650);
            account.CloseACredit();
            CreditCard expected = null;
            
            Assert.Equal(expected, account.Card);
        }
    }
}
