using System;

namespace BankSim.Accounts
{
    class StudentSavingsAccount : SavingsAccount
    {
        public decimal Limit { get; set; }

        public StudentSavingsAccount(string owner) : base(owner)
        {
            Limit = 2000.0M;
            Type = "Studenstký spořící";
        }

        public override void Withdraw(decimal ammount)
        {
            if (Balance < ammount)
            {
                Console.WriteLine("Nedostak prostředků");
            }
            else if (ammount > Limit) { Console.WriteLine("Limit výběru je " + Limit); }
            else
            {
                Balance -= ammount;
                records.Add("Výběr | " + ammount + "Kč");
            }
        }
    }
}
