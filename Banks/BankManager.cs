namespace Banks
{
    public class BankManager : IBank
    {
        public void ChangeDebitPercent(Bank bank, float percent)
        {
            bank.ToBuilder().WithPercentForDebit(percent).Build();
            foreach (Client clinet in bank.DebitFollowers)
            {
                clinet.Message = "percent changed";
            }
        }

        public void ChangeDepositPercent(Bank bank, float percent)
        {
            bank.ToBuilder().WithPercentForDeposit(percent).Build();
            foreach (Client clinet in bank.DepositFollowers)
            {
                clinet.Message = "percent changed";
            }
        }

        public void ChangeCommission(Bank bank, float commission)
        {
            bank.ToBuilder().WithCommission(commission).Build();
            foreach (Client clinet in bank.CreditFollowers)
            {
                clinet.Message = "commission changed";
            }
        }
    }
}
