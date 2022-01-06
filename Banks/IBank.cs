namespace Banks
{
    public interface IBank
    {
        public void ChangeDebitPercent(Bank bank, float percent);
        public void ChangeDepositPercent(Bank bank, float percent);
        public void ChangeCommission(Bank bank, float commission);
    }
}
