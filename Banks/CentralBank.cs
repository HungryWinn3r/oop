using System;

namespace Banks
{
    public class CentralBank
    {
        public Bank AddBank(int percentForDebit, int percentForDeposit, int commission)
        {
            var newBank = new Bank(percentForDebit, percentForDeposit, commission);
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
            return newCreditAccount;
        }

        public Account AddDebitAccount(Client client, Bank bank, int money)
        {
            var newDebitAccount = new Account(client, bank, money);
            bank.AccountsInBank.Add(newDebitAccount);
            bank.ClientsInBank.Add(client);
            return newDebitAccount;
        }

        public Account AddDepositAccount(Client client, DateTime dateTime, Bank bank, int percent, int money)
        {
            var newDepositAccount = new Account(client, dateTime, bank, percent, money);
            bank.AccountsInBank.Add(newDepositAccount);
            bank.ClientsInBank.Add(client);
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

        public void TransferMoney(Account account, Account account1, int moneyToTransfer)
        {
            if (account1.Money >= moneyToTransfer)
            {
                account.ToBuilder().WithMoney(account.Money + moneyToTransfer).BuildDebitAcc();
                account1.ToBuilder().WithMoney(account1.Money - moneyToTransfer).BuildDebitAcc();
                account.LastTrans += moneyToTransfer;
            }
        }

        public void MoneyBack(Account account, Account account1)
        {
            account.ToBuilder().WithMoney(account.Money - account.LastTrans).BuildDebitAcc();
            account1.ToBuilder().WithMoney(account1.Money + account.LastTrans).BuildDebitAcc();
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
    }
}
