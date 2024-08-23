using BankAccount;
using System;
using static BankAccount.Program;

namespace BankAccount.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void TestDeposit()
        {
            //Arrange
            IBankAccountService _bankService = new BankAccountService();
            decimal amount = 22.2m;
            //Act
            _bankService.Deposit(amount);
            var allBalance = _bankService.GetBalance();
            //Assert
            Assert.Contains(allBalance, item => item.Balance == amount);
        }

        [Fact]
        public void TestWithdrawal()
        {
            //Arrange
            IBankAccountService _bankService = new BankAccountService();
            decimal depAmount = 30m;
            decimal withdrawalAmount = 10m;
            decimal expectedAmount = 30m - 10m;
            //Act
            _bankService.Deposit(depAmount);
            _bankService.Withdrawal(withdrawalAmount);
            var allBalance = _bankService.GetBalance();
            //Assert
            Assert.Contains(allBalance, item => item.Balance == expectedAmount);

        }

        [Fact]
        public void TestBalance()
        {
            //Arrange
            IBankAccountService _bankService = new BankAccountService();
            decimal amount1 = 30m;
            decimal amount2 = 20m;
            decimal expectedTotalBalance = amount1 + amount2;
            //Act
            _bankService.Deposit(amount1);
            _bankService.Deposit(amount2);
            var allAccounts = _bankService.GetBalance();
            decimal totalBalance = allAccounts.Sum(account => account.Balance);
            //Assert
            Assert.Equal(expectedTotalBalance, totalBalance);

        }
    }
}