using System;

namespace Banks
{
    public class CentralBank : ICentralBank
    {
        private readonly TransferStory transferStory = new TransferStory();

        public Bank AddBank(int percentForDebit, int percentForDeposit, int commission, float limitForTrans)
        {
            var newBank = new Bank(percentForDebit, percentForDeposit, commission, limitForTrans);
            return newBank;
        }

        public void TransferMoney(Account recipientAccount, Account senderAccount, int moneyToTransfer) // кому-откуда
        {
            if (senderAccount.Owner.Address == null && senderAccount.Owner.Passport == null)
            {
                if (senderAccount.Money >= moneyToTransfer && senderAccount.AccBank.LimitForTrans <= moneyToTransfer)
                {
                    recipientAccount.ToBuilder().WithMoney(recipientAccount.Money + moneyToTransfer).BuildDebitAcc();
                    senderAccount.ToBuilder().WithMoney(senderAccount.Money - moneyToTransfer).BuildDebitAcc();
                    transferStory.Recipients.Add(recipientAccount);
                    transferStory.Senders.Add(senderAccount);
                    transferStory.TransactionAmount.Add(moneyToTransfer);
                }
            }
            else
            {
                if (senderAccount.Money >= moneyToTransfer)
                {
                    recipientAccount.ToBuilder().WithMoney(recipientAccount.Money + moneyToTransfer).BuildDebitAcc();
                    senderAccount.ToBuilder().WithMoney(senderAccount.Money - moneyToTransfer).BuildDebitAcc();
                    transferStory.Recipients.Add(recipientAccount);
                    transferStory.Senders.Add(senderAccount);
                    transferStory.TransactionAmount.Add(moneyToTransfer);
                }
            }
        }

        public void MoneyBack(Account senderAccount, Account recipientAccount) // откуда-куда
        {
            foreach (Account accSender in transferStory.Senders)
            {
                foreach (Account accRecipient in transferStory.Recipients)
                {
                    if (recipientAccount.Id == accSender.Id && senderAccount.Id == accRecipient.Id)
                    {
                        senderAccount.ToBuilder().WithMoney(senderAccount.Money - transferStory.TransactionAmount[senderAccount.Id]).BuildDebitAcc();
                        recipientAccount.ToBuilder().WithMoney(recipientAccount.Money + transferStory.TransactionAmount[senderAccount.Id]).BuildDebitAcc();
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
    }
}
