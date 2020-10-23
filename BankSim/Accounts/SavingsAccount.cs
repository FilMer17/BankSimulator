using System;

namespace BankSim.Accounts
{
    class SavingsAccount : Account
    {
        public SavingsAccount(string owner) : base(owner) 
        {
            Interest = 2;
            LastInterest = Created;
            Type = "Spořící";
        }

        public override void Deposit(decimal ammount)
        {
            Balance += ammount;
            records.Add("Vklad - " + ammount + "Kč");
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
                records.Add("Výběr - " + ammount + "Kč");
            }
        }

        public override void AddInterest()
        {
            Balance = Balance * (decimal)(1 + ((Interest / 100) / 12));
        }
    }
}
