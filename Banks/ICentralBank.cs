using System;

namespace Banks
{
    public interface ICentralBank
    {
        public Bank AddBank(int percentForDebit, int percentForDeposit, int commission, float limitForTrans);
        public void TransferMoney(Account account, Account account1, int moneyToTransfer);
        public void MoneyBack(Account account, Account account1);
        public float WaitDepositAcc(Account account, DateTime dateTime, Bank bank);
        public float WaitDebitAcc(Account account, DateTime dateTime, Bank bank);
        public float WaitCreditAcc(Account account, DateTime dateTime, Bank bank);
    }
}
