using System;

namespace BankSim.Accounts
{
    class CreditAccount : Account
    {
        public CreditAccount(string owner) : base(owner)
        {
            Interest = 12;
            Balance = 50000.0M;
            Type = "Kreditní";
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

        public override void TakeInterest()
        {
            if (Balance >= 50000.0M) { }
            else
            {
                Balance = Balance - (Balance * (decimal)(Interest / 100));
            }

        }
    }
}
