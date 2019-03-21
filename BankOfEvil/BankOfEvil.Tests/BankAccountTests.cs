using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankOfEvil.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        /* Kontostand abfragen
         * Betrag einzahlen
         * -> nicht negativ
         * Betrag abheben
         * -> nicht negativ
         * -> darf nicht unter 0
         * 
         * Neues Konto hat standardmäßig einen Kontostand von 0
         */
        [TestMethod]
        public void BankAccount_New_Konto_Has_0_Balance()
        {
            var a = new BankAccount();
            Assert.AreEqual(0, a.Balance);
        }

        #region Deposit()
        [TestMethod]
        public void BankAccount_can_Deposit()
        {
            var a = new BankAccount();

            a.Deposit(5m);
            Assert.AreEqual(5m, a.Balance);

            a.Deposit(3m);
            Assert.AreEqual(8m, a.Balance);
        }

        // Was wenn der Kunde 0 einzahlt ? 
        [TestMethod]
        public void BankAccount_Deposit_0_Balance_does_not_change()
        {
            var a = new BankAccount();
            a.Deposit(5.333333333m);

            a.Deposit(0m);
            Assert.AreEqual(5.333333333m, a.Balance);
        }

        // Was wenn der Kunde -2m einzahlt ?
        [TestMethod]
        [DataRow(-1)]
        [DataRow(-10)]
        public void BankAccount_Deposit_Negative_Value_Throws_ArgumentException(decimal negativeValue)
        {
            var a = new BankAccount();
            Assert.ThrowsException<ArgumentException>(() => a.Deposit(negativeValue));
        }

        [TestMethod]
        public void BankAccount_Deposit_over_MaxValue_Throws_OverflowException()
        {
            var a = new BankAccount();
            a.Deposit(decimal.MaxValue);

            Assert.ThrowsException<OverflowException>(() => a.Deposit(1m));
        }
        #endregion

        #region Withdraw()
        [TestMethod]
        public void BankAccount_can_Withdraw()
        {
            var a = new BankAccount();
            a.Deposit(10m);

            a.Withdraw(3m);
            Assert.AreEqual(7m, a.Balance);

            a.Withdraw(5m);
            Assert.AreEqual(2m, a.Balance);
        }

        [TestMethod]
        public void BankAccount_Withdraw_0_Balance_does_not_change()
        {
            var a = new BankAccount();
            a.Deposit(10.55555m);

            a.Withdraw(0m);
            Assert.AreEqual(10.55555m, a.Balance);
        }

        [TestMethod]
        public void BankAccount_Withdraw_over_Balance_throws_InvalidOperationException()
        {
            var a = new BankAccount();
            a.Deposit(10m);

            Assert.ThrowsException<InvalidOperationException>(() => a.Withdraw(12m));
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-10)]
        public void BankAccount_Withdraw_Negative_Value_Throws_ArgumentException(decimal negativeValue)
        {
            var a = new BankAccount();
            a.Deposit(10m);
            Assert.ThrowsException<ArgumentException>(() => a.Withdraw(negativeValue));
        }

        [TestMethod]
        public void BankAccount_Withdraw_under_MinValue_Throws_OverflowException()
        {
            var a = new BankAccount();
            a.Withdraw(decimal.MinValue);

            Assert.ThrowsException<OverflowException>(() => a.Withdraw(1m));
        }
        #endregion

        // Zustand wäre bereit zum "einchecken"
    }
}
