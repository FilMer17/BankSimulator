using System;
using BankSim.Accounts;
using BankSim.Dependencies;
using System.Collections.Generic;

namespace BankSim
{
    class Program
    {
        private static BankTime btime = new BankTime();
        private static List<SavingsAccount> accounts = new List<SavingsAccount>();
        private static SavingsAccount saveAccs;

        static void Main(string[] args)
        {
            bool exit = false;
            int number;
            decimal ammount;

            accounts.Add(new SavingsAccount("Filip Merta"));
            accounts[0].Deposit(5000);

            btime.SetTime();

            while (exit != true)
            {
                number = default;
                ammount = default;

                Console.Write("Příkaz: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "+ucet":
                        Console.Write("Jméno: ");
                        string owner = Console.ReadLine();
                        AddAccount(owner);
                        break;

                    case "vklad":
                        WriteAccounts();
                        Console.Write("Číslo účtu: ");
                        number = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Hodnota vkladu: ");
                        ammount = Convert.ToDecimal(Console.ReadLine());
                        accounts[number].Deposit(ammount);
                        break;

                    case "vyber":
                        WriteAccounts();
                        Console.Write("Číslo účtu: ");
                        number = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Hodnota vyberu: ");
                        ammount = Convert.ToDecimal(Console.ReadLine());
                        accounts[number].Withdraw(ammount);
                        break;

                    case "ucty":
                        WriteAccounts();
                        break;

                    case "+den":
                        Console.Write("Kolik dní: ");
                        number = Convert.ToInt32(Console.ReadLine());
                        btime.AddDays(number);
                        break;

                    case "+mesic":
                        Console.Write("Kolik měsíců: ");
                        number = Convert.ToInt32(Console.ReadLine());
                        btime.AddMonths(number);
                        break;

                    case "cas":
                        btime.WriteTime();
                        break;

                    case "clear":
                        Console.Clear();
                        break;

                    case "exit":
                        exit = true;
                        break;

                    case "inter":
                        WriteAccounts();
                        Console.Write("Číslo účtu: ");
                        number = Convert.ToInt32(Console.ReadLine());
                        accounts[number].AddInterest();
                        break;

                    default:
                        Console.WriteLine("Neplatná volba");
                        break;
                }
            }

        }
        public static void AddAccount(string owner)
        {
            saveAccs = new SavingsAccount(owner);
            accounts.Add(saveAccs);
        }

        public static void WriteAccounts()
        {
            int i = 0;
            foreach (var item in accounts)
            {
                Console.WriteLine(i + " | " + item.Owner + " | " + item.Created + " | " + item.Balance);
                i++;
            }
        }

        public DateTime GetBankTime()
        {
            return btime.Time;
        }

        public List<SavingsAccount> GetAccounts()
        {
            return accounts;
        }
    }
}
