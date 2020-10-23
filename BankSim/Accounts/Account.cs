using System;
using System.Collections.Generic;

namespace BankSim.Accounts
{
    abstract class Account
    {
        private Program pg = new Program();

        public string Owner { get; set; }
        public decimal Balance { get; set; }
        public DateTime Created { get; set; }
        public double Interest { get; set; }
        public DateTime LastInterest { get; set; }
        public string Type { get; set; }

        public List<string> records = new List<string>();

        public Account(string owner)
        {
            Owner = owner;
            Balance = 0.0M;
            Created = pg.GetBankTime();
            Type = "";
        }

        public abstract void Deposit(decimal ammount);
        public abstract void Withdraw(decimal ammount);
        public virtual void AddInterest()
        { 
        
        }
        public virtual void TakeInterest()
        {

        }
    }
}
