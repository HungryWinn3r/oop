using System;

namespace Banks
{
    public interface ICentralBank
    {
        Bank AddBank(int percentForDebit, int percentForDeposit, int commission, float limitForTrans);
        void TransferMoney(Account recipientAccount, Account senderAccount, int moneyToTransfer);
        void MoneyBack(Account senderAccount, Account recipientAccount);
        float WaitDepositAcc(Account account, DateTime dateTime, Bank bank);
        float WaitDebitAcc(Account account, DateTime dateTime, Bank bank);
        float WaitCreditAcc(Account account, DateTime dateTime, Bank bank);
    }
}
