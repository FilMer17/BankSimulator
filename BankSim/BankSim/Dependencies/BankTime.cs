using System;
using System.Timers;
using BankSim.Accounts;
using System.Collections.Generic;

namespace BankSim.Dependencies
{
    class BankTime
    {
        private Program pg = new Program();
        public DateTime Time { get; set; }
        
        public DateTime temp;
        public TimeSpan diff;
        public Timer timer;
        public List<SavingsAccount> SaveAccs;

        public BankTime()
        {
            Time = new DateTime(2020, 10, 17, 9, 0, 0);
        }

        public void AddHours(double numberOfHours)
        {
            Time = Time.AddHours(numberOfHours);
        }

        public void AddDays(double numberOfDays)
        {
            Time = Time.AddDays(numberOfDays);
        }

        public void AddMonths(int numberOfMonths)
        {
            Time = Time.AddMonths(numberOfMonths);
        }

        public void SetTime()
        {
            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void WriteTime()
        {
            Console.WriteLine("Čas - {0:dd/MM/yyyy} | {0:HH:mm:ss}", Time, Time);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            temp = Time;
            SaveAccs = pg.GetAccounts();
            foreach (var item in SaveAccs)
            {
                diff = temp.Subtract(item.LastInterest);
                if (diff.Days > 30)
                {
                    for (int i = 0; i < diff.Days / 30; i++)
                    {
                        timer.Stop();
                        item.AddInterest();
                        item.LastInterest = Time;
                        timer.Start();
                    }
                }
            }
            Time = Time.AddSeconds(1);
        }
    }
}
