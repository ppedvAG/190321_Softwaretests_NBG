using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfEvil
{
    public enum Wealth { CreditHell,StudentLoans,Debit,Zero, Poor,MiddleClass,Rich,FilthyRich}
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
        public Wealth Wealth
        {
            get
            {
                switch (Balance)
                {
                    case decimal b when b < -1_000_000:
                        return Wealth.CreditHell;
                    case decimal b when b < -100_000:
                        return Wealth.StudentLoans;
                    case decimal b when b < 0:
                        return Wealth.Debit;
                    case decimal b when b == 0:
                        return Wealth.Zero;
                    case decimal b when b < 1_000:
                        return Wealth.Poor;
                    case decimal b when b < 100_000:
                        return Wealth.MiddleClass;
                    case decimal b when b < 1_000_000:
                        return Wealth.Rich;
                    case decimal b when b >= 1_000_000:
                        return Wealth.FilthyRich;
                    default:
                        return Wealth.Zero;
                }
            }
        }

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
