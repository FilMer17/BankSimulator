using System;

namespace BankSim.Accounts
{
    class CreditAccount : Account
    {
        public int Doba { get; set; }
        public CreditAccount(string owner, decimal money, int doba) : base(owner)
        {
            Doba = doba;
            Balance = -money;
            LastInterest = Created;
            Interest = (double)Balance * (Doba / 100) * 0.2;
            Type = "Kreditní";
        }

        public override void Deposit(decimal ammount)
        {
            Balance += ammount;
            records.Add("Vklad | " + ammount + "Kč");
        }

        public override void Withdraw(decimal ammount)
        {
            Balance -= ammount;
            records.Add("Výběr | " + ammount + "Kč");
        }

        public override void TakeInterest()
        {
            if (Balance >= 0) 
            {
            
            }
            else
            {
                Interest = (double)Balance * (Doba - (pg.GetBankTime().Subtract(Created).TotalDays / 30) / 100) * 0.2;
                Balance += (decimal)(Interest / 100);
            }

        }
    }
}
