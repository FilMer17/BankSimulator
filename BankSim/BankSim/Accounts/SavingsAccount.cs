using System;

namespace BankSim.Accounts
{
    class SavingsAccount : Account
    {
        public double Interest { get; set; }
        public DateTime LastInterest { get; set; }

        public SavingsAccount(string owner) : base(owner) 
        {
            Interest = 2;
            LastInterest = Created;
        }

        public override void Deposit(decimal ammount)
        {
            Balance += ammount;
        }

        public override void Withdraw(decimal ammount)
        {
            if (Balance < ammount)
            {
                Console.WriteLine("Nedostak prostředků");
            }
            else
            {
                Balance -= ammount;
            }
        }

        public void AddInterest()
        {
            Balance = Balance * (decimal)(1 + ((Interest / 100) / 12));
        }
    }
}
