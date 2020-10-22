using System;

namespace BankSim.Accounts
{
    abstract class Account
    {
        private Program pg = new Program();

        public string Owner { get; set; }
        public decimal Balance { get; set; }
        public DateTime Created { get; set; }

        public Account(string owner)
        {
            Owner = owner;
            Balance = 0.0M;
            Created = pg.GetBankTime();
        }

        public abstract void Deposit(decimal ammount);
        public abstract void Withdraw(decimal ammount);
    }
}
