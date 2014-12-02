using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace AccountTest
{
    [TestClass]
    public class Tester
    {
        [TestMethod]
        public void testConstructorNegativeAmount()
        {
            BankAccount account = new BankAccount("Matti", -1);
            Assert.AreEqual(account.Balance, -1);
            //
        }
        [TestMethod]
        public void testConstructorPositiveAmount()
        {
            BankAccount account = new BankAccount("Matti", 1);
            Assert.AreEqual(account.Balance, 1);
        }
        [TestMethod]
        public void testConstructorPositiveDouble()
        {
            BankAccount account = new BankAccount("Matti", 1.11);
            Assert.AreEqual(account.Balance, 1.11);
        }
        [TestMethod]
        public void testConstructorTooHighAmount()
        {
            BankAccount account = new BankAccount("Matti", Double.MaxValue + 1000);
            //Not higher than max double
            Assert.AreEqual(account.Balance, Double.MaxValue);
        }
        [TestMethod]
        public void testDebitTooMuch()
        {
            BankAccount account = new BankAccount("Matti", 500);
            account.Debit(501);
            //Assert that it did not change the balance
            Assert.AreEqual(account.Balance, 500);
        }
        [TestMethod]
        public void testDebitTooLittle()
        {
            BankAccount account = new BankAccount("Matti", 500);
            account.Debit(-1);
            //Assert that it did not change the balance
            Assert.AreEqual(account.Balance, 500);
        }
        [TestMethod]
        public void testDebitNormal()
        {
            BankAccount account = new BankAccount("Matti", 500);
            account.Debit(250);
            Assert.AreEqual(account.Balance, 250);
        }
        [TestMethod]
        public void testCreditOverBalance()
        {
            BankAccount account = new BankAccount("Matti", 500);
            account.Credit(501);
            //Assert that it did become negative
            Assert.AreEqual(account.Balance, 500 - 501);
        }
        [TestMethod]
        public void testCreditTooMuch()
        {
            BankAccount account = new BankAccount("Matti", 500);
            account.Credit(6000);
            //Assert that the account froze
            Assert.AreEqual(account.Frozen, true);
        }
        [TestMethod]
        public void testCreditTooLittle()
        {
            BankAccount account = new BankAccount("Matti", 500);
            account.Credit(-1);
            //Assert that it did not change the balance
            Assert.AreEqual(account.Balance, 500);
        }
        [TestMethod]
        public void testDepositNormal()
        {
            BankAccount account = new BankAccount("Matti", 500);
            account.Deposit(500);
            Assert.AreEqual(account.Balance, 500 + 500);
        }
        [TestMethod]
        public void testDepositTooLittle()
        {
            BankAccount account = new BankAccount("Matti", 500);
            account.Deposit(-1);
            Assert.AreEqual(account.Balance, 500);
        }
    }
}

