using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    {
        public decimal Balance { get; set; }

        public Account(decimal balance)
        {
            Balance = balance;
        }
    }
}
