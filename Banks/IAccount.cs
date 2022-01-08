using System;

namespace Banks
{
    public interface IAccount
    {
        Account AddCreditAccount(Client client, int limit, Bank bank);
        Account AddDebitAccount(Client client, Bank bank, int money);
        Account AddDepositAccount(Client client, DateTime dateTime, Bank bank, int money);
        void ChangeDepositDate(Account account, DateTime date);
        void AddMoneyToDepositAcc(Account account, int money);
        void AddMoneyToDebitAcc(Account account, int money);
        void AddMoneyToCreditAcc(Account account, int money);
        void TakeMoneyFromDepositAcc(Account account, int money, DateTime date);
        void TakeMoneyFromDebitAcc(Account account, int money);
        void TakeMoneyFromCreditAcc(Account account, int money);
    }
}
