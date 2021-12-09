using System;

namespace Banks
{
    public class Account
    {
        public Account(Client client, float limit, Bank bank)
        {
            Owner = client;
            Credit = limit;
            MaxCredit = limit;
            AccBank = bank;
            Id = IdMaker.MakeId();
            LastTrans = 0;
        }

        public Account(Client client, DateTime dateTime, Bank bank, float percent, float curMoney)
        {
            Owner = client;
            Money = curMoney;
            Date = dateTime;
            AccBank = bank;
            PercentPerDay = percent / 365;
            Id = IdMaker.MakeId();
            LastTrans = 0;
        }

        public Account(Client client, Bank bank, float curMoney)
        {
            Owner = client;
            Money = curMoney;
            AccBank = bank;
            Id = IdMaker.MakeId();
            LastTrans = 0;
        }

        public float MaxCredit { get; }

        public float LastTrans { get; set; }

        public int Id { get; }

        public float PercentPerDay { get; }

        public float Percent { get; }

        public Bank AccBank { get; }

        public Client Owner { get; }

        public DateTime Date { get; }

        public float Credit { get; }

        public float Money { get; }

        public AccountBuilder ToBuilder()
        {
            var accountBuilder = new AccountBuilder();
            accountBuilder.WithOwner(Owner);
            accountBuilder.WithCredit(Credit);
            accountBuilder.WithAccBank(AccBank);
            accountBuilder.WithDate(Date);
            accountBuilder.WithPercent(Percent);
            accountBuilder.WithMoney(Money);
            return accountBuilder;
        }

        public class AccountBuilder
        {
            private Client _owner;
            private float _credit;
            private Bank _accBank;
            private DateTime _date;
            private float _percent;
            private float _money;

            public AccountBuilder WithOwner(Client owner)
            {
                _owner = owner;
                return this;
            }

            public AccountBuilder WithCredit(float credit)
            {
                _credit = credit;
                return this;
            }

            public AccountBuilder WithAccBank(Bank bank)
            {
                _accBank = bank;
                return this;
            }

            public AccountBuilder WithDate(DateTime dateTime)
            {
                _date = dateTime;
                return this;
            }

            public AccountBuilder WithPercent(float percent)
            {
                _percent = percent;
                return this;
            }

            public AccountBuilder WithMoney(float money)
            {
                _money = money;
                return this;
            }

            public Account BuildDebitAcc()
            {
                var finalDebitAcc = new Account(_owner, _accBank, _money);
                return finalDebitAcc;
            }

            public Account BuildCreditAcc()
            {
                var finalCreditAcc = new Account(_owner, _credit, _accBank);
                return finalCreditAcc;
            }

            public Account BuildDepositAcc()
            {
                var finalDepositAcc = new Account(_owner, _date, _accBank, _percent, _money);
                return finalDepositAcc;
            }
        }
    }
}
