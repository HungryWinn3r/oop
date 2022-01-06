using System;
using System.Collections.Generic;

namespace Banks
{
    public class CentralBank : ICentralBank
    {
        private readonly List<Account> accFrom = new List<Account>();
        private readonly List<Account> accTo = new List<Account>();
        private readonly List<float> transferStory = new List<float>();

        public Bank AddBank(int percentForDebit, int percentForDeposit, int commission, float limitForTrans)
        {
            var newBank = new Bank(percentForDebit, percentForDeposit, commission, limitForTrans);
            return newBank;
        }

        public void TransferMoney(Account account, Account account1, int moneyToTransfer) // кому-откуда
        {
            if (account.Owner.Level < 3)
            {
                if (account1.Money >= moneyToTransfer && account1.AccBank.LimitForTrans <= moneyToTransfer)
                {
                    account.ToBuilder().WithMoney(account.Money + moneyToTransfer).BuildDebitAcc();
                    account1.ToBuilder().WithMoney(account1.Money - moneyToTransfer).BuildDebitAcc();
                    accTo.Add(account);
                    accFrom.Add(account1);
                    transferStory.Add(moneyToTransfer);
                }
            }

            if (account.Owner.Level >= 3)
            {
                if (account1.Money >= moneyToTransfer)
                {
                    account.ToBuilder().WithMoney(account.Money + moneyToTransfer).BuildDebitAcc();
                    account1.ToBuilder().WithMoney(account1.Money - moneyToTransfer).BuildDebitAcc();
                    accTo.Add(account);
                    accFrom.Add(account1);
                    transferStory.Add(moneyToTransfer);
                }
            }
        }

        public void MoneyBack(Account account, Account account1) // откуда-куда
        {
            foreach (Account acc in accFrom)
            {
                foreach (Account acc1 in accTo)
                {
                    if (account1.Id == acc.Id && account.Id == acc1.Id)
                    {
                        account.ToBuilder().WithMoney(account.Money - transferStory[account.Id]).BuildDebitAcc();
                        account1.ToBuilder().WithMoney(account1.Money + transferStory[account.Id]).BuildDebitAcc();
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
