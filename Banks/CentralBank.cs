using System;
using System.Collections.Generic;

namespace Banks
{
    public class CentralBank
    {
        private readonly List<Account> accFrom = new List<Account>();
        private readonly List<Account> accTo = new List<Account>();
        private readonly List<float> moneyStory = new List<float>();

        public Bank AddBank(int percentForDebit, int percentForDeposit, int commission, float limitForTrans)
        {
            var newBank = new Bank(percentForDebit, percentForDeposit, commission, limitForTrans);
            return newBank;
        }

        public Client AddClient(string name, string surname)
        {
            var newClient = new Client(name, surname);
            return newClient;
        }

        public Account AddCreditAccount(Client client, int limit, Bank bank)
        {
            var newCreditAccount = new Account(client, limit, bank);
            bank.AccountsInBank.Add(newCreditAccount);
            bank.ClientsInBank.Add(client);
            bank.CreditFollowers.Add(client);
            return newCreditAccount;
        }

        public Account AddDebitAccount(Client client, Bank bank, int money)
        {
            var newDebitAccount = new Account(client, bank, money);
            bank.AccountsInBank.Add(newDebitAccount);
            bank.ClientsInBank.Add(client);
            bank.DebitFollowers.Add(client);
            return newDebitAccount;
        }

        public Account AddDepositAccount(Client client, DateTime dateTime, Bank bank, int money)
        {
            var newDepositAccount = new Account(client, dateTime, bank, money);
            bank.AccountsInBank.Add(newDepositAccount);
            bank.ClientsInBank.Add(client);
            bank.DepositFollowers.Add(client);
            return newDepositAccount;
        }

        public void ChangeDepositDate(Account account, DateTime date)
        {
            account.ToBuilder().WithDate(date).BuildDepositAcc();
        }

        public void AddMoneyToDepositAcc(Account account, int money)
        {
            account.ToBuilder().WithMoney(account.Money + money).BuildDepositAcc();
        }

        public void AddMoneyToDebitAcc(Account account, int money)
        {
            account.ToBuilder().WithMoney(account.Money + money).BuildDebitAcc();
        }

        public void AddMoneyToCreditAcc(Account account, int money)
        {
            account.ToBuilder().WithMoney(account.Credit + money).BuildDebitAcc();
        }

        public void TakeMoneyFromDepositAcc(Account account, int money, DateTime date)
        {
            if (account.Owner.Level == 1)
            {
                if (account.Money >= money && date >= account.Date && account.AccBank.LimitForTrans <= money)
                {
                    account.ToBuilder().WithMoney(account.Money - money).BuildDepositAcc();
                }
            }

            if (account.Owner.Level == 2)
            {
                if (account.Money >= money && date >= account.Date)
                {
                    account.ToBuilder().WithMoney(account.Money - money).BuildDepositAcc();
                }
            }
        }

        public void TakeMoneyFromDebitAcc(Account account, int money)
        {
            if (account.Owner.Level == 1)
            {
                if (account.Money >= money && account.AccBank.LimitForTrans <= money)
                {
                    account.ToBuilder().WithMoney(account.Money - money).BuildDebitAcc();
                }
            }

            if (account.Owner.Level == 2)
            {
                if (account.Money >= money)
                {
                    account.ToBuilder().WithMoney(account.Money - money).BuildDebitAcc();
                }
            }
        }

        public void TakeMoneyFromCreditAcc(Account account, int money)
        {
            if (account.Owner.Level == 1)
            {
                if (account.Credit >= money && account.AccBank.LimitForTrans <= money)
                {
                    account.ToBuilder().WithMoney(account.Credit - money).BuildDebitAcc();
                }
            }

            if (account.Owner.Level == 2)
            {
                if (account.Credit >= money)
                {
                    account.ToBuilder().WithMoney(account.Credit - money).BuildDebitAcc();
                }
            }
        }

        public void TransferMoney(Account account, Account account1, int moneyToTransfer)
        {
            if (account1.Money >= moneyToTransfer)
            {
                account.ToBuilder().WithMoney(account.Money + moneyToTransfer).BuildDebitAcc();
                account1.ToBuilder().WithMoney(account1.Money - moneyToTransfer).BuildDebitAcc();
                accTo.Add(account);
                accFrom.Add(account1);
                moneyStory.Add(moneyToTransfer);
            }
        }

        public void MoneyBack(Account account, Account account1)
        {
            foreach (Account acc in accFrom)
            {
                foreach (Account acc1 in accTo)
                {
                    if (account1.Id == acc.Id && account.Id == acc1.Id)
                    {
                        account.ToBuilder().WithMoney(account.Money - moneyStory[account.Id]).BuildDebitAcc();
                        account1.ToBuilder().WithMoney(account1.Money + moneyStory[account.Id]).BuildDebitAcc();
                    }
                }
            }
        }

        public float WaitDepositAcc(Account account, DateTime dateTime, Bank bank)
        {
            TimeSpan time = dateTime.Subtract(account.Date);
            float timeSpened = (float)time.TotalDays;
            account.ToBuilder().WithMoney(account.Money * bank.PercentForDepositPerDay * timeSpened).BuildDepositAcc();
            return account.Money;
        }

        public float WaitDebitAcc(Account account, DateTime dateTime, Bank bank)
        {
            TimeSpan time = dateTime.Subtract(account.Date);
            float timeSpened = (float)time.TotalDays;
            account.ToBuilder().WithMoney(account.Money * bank.PercentForDebitPerDay * timeSpened).BuildDebitAcc();
            return account.Money;
        }

        public float WaitCreditAcc(Account account, DateTime dateTime, Bank bank)
        {
            TimeSpan time = dateTime.Subtract(account.Date);
            float timeSpened = (float)time.TotalDays;
            float commission = (account.MaxCredit - account.Credit) * bank.CommissionPerDay * timeSpened;
            account.ToBuilder().WithCredit(account.Credit - commission).BuildCreditAcc();
            return account.Credit;
        }

        public void ChangeDebitPercent(Bank bank, float percent)
        {
            bank.ToBuilder().WithPercentForDebit(percent).Build();
        }

        public void ChangeDepositPercent(Bank bank, float percent)
        {
            bank.ToBuilder().WithPercentForDeposit(percent).Build();
        }

        public void ChangeCommission(Bank bank, float commission)
        {
            bank.ToBuilder().WithCommission(commission).Build();
        }

        public void PushDebit()
        {
            Console.WriteLine("Проценты по дебетому счету изменены!");
        }

        public void PushDeposit()
        {
            Console.WriteLine("Проценты по депозитному счету изменены!");
        }

        public void PushCredit()
        {
            Console.WriteLine("Проценты по кредитному счету изменены!");
        }
    }
}
