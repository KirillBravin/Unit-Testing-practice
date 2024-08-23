using System;

namespace BankAccount
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }

        public class BankAccountService() : IBankAccountService
        {
            List<Account> accounts = new List<Account>();

            public void Deposit(decimal amount)
            {
                accounts.Add(new Account(amount));
            }

            public void Withdrawal(decimal amount)
            {
                var account = accounts.FirstOrDefault(a => a.Balance >= amount);
                if (account != null)
                {
                    account.Balance -= amount;
                }
                else
                {
                    Console.WriteLine("Insufficient amount.");
                }
            }

            public List<Account> GetBalance()
            {
                return accounts;
            }
        }
    }

    public interface IBankAccountService
    {
        void Deposit(decimal amount);
        void Withdrawal(decimal amount);
        List<Account> GetBalance();
    }
}