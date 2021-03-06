﻿using System;
using Microsoft.QualityTools.Testing.Fakes;
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

        [TestMethod]
        public void BankAccount_New_Konto_Gets_valid_Balance_From_Constructor()
        {
            const decimal validBalanceForConstructor = 10m;
            var a = new BankAccount(validBalanceForConstructor);
            Assert.AreEqual(validBalanceForConstructor, a.Balance);
        }

        [TestMethod]
        public void BankAccount_New_Konto_Gets_invalid_Balance_From_Constructor_Throws_ArgumentException()
        {
            const decimal invalidBalanceForConstructor = -10m;
            Assert.ThrowsException<ArgumentException>(() => new BankAccount(invalidBalanceForConstructor));
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
        public void BankAccount_Deposit_Negative_Value_Throws_ArgumentException()
        {
            var a = new BankAccount();
            Assert.ThrowsException<ArgumentException>(() => a.Deposit(decimal.MinusOne));
        }

        [TestMethod]
        public void BankAccount_Deposit_over_MaxValue_Throws_OverflowException()
        {
            var a = new BankAccount(decimal.MaxValue);

            Assert.ThrowsException<OverflowException>(() => a.Deposit(1m));
        }
        #endregion

        #region Withdraw()
        [TestMethod]
        public void BankAccount_can_Withdraw()
        {
            var a = new BankAccount(10m);

            a.Withdraw(3m);
            Assert.AreEqual(7m, a.Balance);

            a.Withdraw(5m);
            Assert.AreEqual(2m, a.Balance);
        }

        [TestMethod]
        public void BankAccount_Withdraw_0_Balance_does_not_change()
        {
            var a = new BankAccount(10.55555m);

            a.Withdraw(0m);
            Assert.AreEqual(10.55555m, a.Balance);
        }

        [TestMethod]
        public void BankAccount_Withdraw_over_Balance_throws_InvalidOperationException()
        {
            var a = new BankAccount(10m);

            Assert.ThrowsException<InvalidOperationException>(() => a.Withdraw(12m));
        }

        [TestMethod]
        public void BankAccount_Withdraw_Negative_Value_Throws_ArgumentException()
        {
            var a = new BankAccount(10m);
            Assert.ThrowsException<ArgumentException>(() => a.Withdraw(decimal.MinusOne));
        }

        [TestMethod]
        public void BankAccount_Withdraw_under_MinValue_Throws_OverflowException()
        {
            var a = new BankAccount(decimal.MinValue);
            Assert.ThrowsException<OverflowException>(() => a.Withdraw(1m));
        }
        #endregion

        // Zustand wäre bereit zum "einchecken"

        [TestMethod]
        public void BankAccount_Wealth()
        {
            using (ShimsContext.Create())
            {
                var ba = new BankAccount();

                Fakes.ShimBankAccount.AllInstances.BalanceGet = x => 0;
                Assert.AreEqual(Wealth.Zero, ba.Wealth);

                Fakes.ShimBankAccount.AllInstances.BalanceGet = x => 5000;
                Assert.AreEqual(Wealth.MiddleClass, ba.Wealth);

                Fakes.ShimBankAccount.AllInstances.BalanceGet = x => 250_000;
                Assert.AreEqual(Wealth.Rich, ba.Wealth);
            }

        }
    }
}
