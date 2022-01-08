namespace Banks
{
    public interface IBank
    {
        void ChangeDebitPercent(Bank bank, float percent);
        void ChangeDepositPercent(Bank bank, float percent);
        void ChangeCommission(Bank bank, float commission);
    }
}
