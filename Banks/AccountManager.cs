using System;

namespace Banks
{
    public class AccountManager : IAccount
    {
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
            if (account.Owner.Level < 3)
            {
                if (account.Money >= money && date >= account.Date && account.AccBank.LimitForTrans <= money)
                {
                    account.ToBuilder().WithMoney(account.Money - money).BuildDepositAcc();
                }
            }

            if (account.Owner.Level >= 3)
            {
                if (account.Money >= money && date >= account.Date)
                {
                    account.ToBuilder().WithMoney(account.Money - money).BuildDepositAcc();
                }
            }
        }

        public void TakeMoneyFromDebitAcc(Account account, int money)
        {
            if (account.Owner.Level < 3)
            {
                if (account.Money >= money && account.AccBank.LimitForTrans <= money)
                {
                    account.ToBuilder().WithMoney(account.Money - money).BuildDebitAcc();
                }
            }

            if (account.Owner.Level >= 3)
            {
                if (account.Money >= money)
                {
                    account.ToBuilder().WithMoney(account.Money - money).BuildDebitAcc();
                }
            }
        }

        public void TakeMoneyFromCreditAcc(Account account, int money)
        {
            if (account.Owner.Level < 3)
            {
                if (account.Credit >= money && account.AccBank.LimitForTrans <= money)
                {
                    account.ToBuilder().WithMoney(account.Credit - money).BuildDebitAcc();
                }
            }

            if (account.Owner.Level >= 3)
            {
                if (account.Credit >= money)
                {
                    account.ToBuilder().WithMoney(account.Credit - money).BuildDebitAcc();
                }
            }
        }
    }
}
