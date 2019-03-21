using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfEvil
{
    public class BankAccount
    {

        public BankAccount()
        {
        }

        public BankAccount(decimal Balance)
        {
            this.Balance = Balance;
        }

        public decimal Balance { get; protected set; }

        public void Deposit(decimal value)
        {
            if (value < 0)
                throw new ArgumentException();
            Balance += value;
        }

        public void Withdraw(decimal value)
        {
            if (value < 0)
                throw new ArgumentException();
            if (Balance - value < 0)
                throw new InvalidOperationException();
            checked
            {
                Balance -= value;
            }
        }
    }
}
