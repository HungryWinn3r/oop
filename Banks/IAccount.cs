using System;

namespace Banks
{
    public interface IAccount
    {
        public Account AddCreditAccount(Client client, int limit, Bank bank);
        public Account AddDebitAccount(Client client, Bank bank, int money);
        public Account AddDepositAccount(Client client, DateTime dateTime, Bank bank, int money);
        public void ChangeDepositDate(Account account, DateTime date);
        public void AddMoneyToDepositAcc(Account account, int money);
        public void AddMoneyToDebitAcc(Account account, int money);
        public void AddMoneyToCreditAcc(Account account, int money);
        public void TakeMoneyFromDepositAcc(Account account, int money, DateTime date);
        public void TakeMoneyFromDebitAcc(Account account, int money);
        public void TakeMoneyFromCreditAcc(Account account, int money);
    }
}
