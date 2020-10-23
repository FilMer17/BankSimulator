using System;
using BankSim.Accounts;
using BankSim.Dependencies;
using System.Collections.Generic;

namespace BankSim
{
    class Program
    {
        private static BankTime btime = new BankTime();
        private static List<Account> accounts = new List<Account>();
        private static SavingsAccount saveAccs;
        private static CreditAccount credAccs;
        private static StudentSavingsAccount studSaveAccs;

        static void Main(string[] args)
        {
            bool exit = false;
            int number;
            decimal ammount;

            accounts.Add(new SavingsAccount("Filip"));
            accounts[0].Deposit(30000);
            accounts.Add(new CreditAccount("Tomáš"));
            accounts.Add(new StudentSavingsAccount("Ondřej"));
            accounts[2].Deposit(15000);

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
                        Console.Write("typ (spor, sporstu, kred) : ");
                        string type = Console.ReadLine();
                        AddAccount(owner, type);
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

                    case "zaznam":
                        WriteAccounts();
                        Console.Write("Číslo účtu: ");
                        number = Convert.ToInt32(Console.ReadLine());
                        foreach (var item in accounts[number].records)
                        {
                            Console.WriteLine(item);
                        }
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

                    default:
                        Console.WriteLine("Neplatná volba");
                        break;
                }
            }

        }
        public static void AddAccount(string owner, string type)
        {
            switch (type)
            {
                case "spor":
                    saveAccs = new SavingsAccount(owner);
                    accounts.Add(saveAccs);
                    break;
                case "sporstud":
                    studSaveAccs = new StudentSavingsAccount(owner);
                    accounts.Add(studSaveAccs);
                    break;
                case "kred":
                    credAccs = new CreditAccount(owner);
                    accounts.Add(credAccs);
                    break;
                default:
                    Console.WriteLine("Špatný typ");
                    break;
            }
        }

        public static void WriteAccounts()
        {
            int i = 0;
            foreach (var item in accounts)
            {
                Console.WriteLine(i + " | " + item.Type + " | " + item.Owner + " | " + item.Created + " | " + item.Balance);
                i++;
            }
        }

        public DateTime GetBankTime()
        {
            return btime.Time;
        }

        public List<Account> GetAccounts()
        {
            return accounts;
        }
    }
}
