using System;

namespace BankAccountNS
{
    public class BankAccount
    {
        private string customerName;
        private double balance;
        private bool accountFrozen = false;
        private const int negativeLimit = -5000;

        private BankAccount() {
        }

        public BankAccount(string customerName, double balance) {
            this.customerName = customerName;
            this.balance = balance;
        }

        public string CustomerName {
            get { return customerName; }
        }

        public double Balance {
            get { return balance; }
        }

        public bool Frozen
        {
            get { return accountFrozen; }
        }

        public void Deposit(double amount) {
            if (!accountFrozen && amount > 0) {
                balance += amount;
            }
        }

        public void Debit(double amount) {
            if (!accountFrozen && amount < balance && amount > 0) {
                balance -= amount;
            }
        }

        public void Credit(double amount) {
            if ((balance - amount) < negativeLimit && !accountFrozen) {
                accountFrozen = true;
                balance -= amount;
            }
            if (!accountFrozen && amount > 0) {
                balance -= amount;
            }
        }

        public static void Main()
        {
            BankAccount account = new BankAccount("Heikki", 53.10);
            Console.WriteLine("Balance is ${0}", account.Balance);
        }
    }
}
