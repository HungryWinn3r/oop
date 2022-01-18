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
            Limit = bank.LimitForTrans;
            Verification = !(Owner.Address == null || Owner.Passport == null);
        }

        public Account(Client client, DateTime dateTime, Bank bank, float curMoney)
        {
            Owner = client;
            Money = curMoney;
            Date = dateTime;
            AccBank = bank;
            Id = IdMaker.MakeId();
            Verification = !(Owner.Address == null || Owner.Passport == null);
        }

        public Account(Client client, Bank bank, float curMoney)
        {
            Owner = client;
            Money = curMoney;
            AccBank = bank;
            Id = IdMaker.MakeId();
            Limit = bank.LimitForTrans;
            Verification = !(Owner.Address == null || Owner.Passport == null);
        }

        public bool Verification { get; }

        public float Limit { get; }

        public float MaxCredit { get; }

        public int Id { get; }

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
            accountBuilder.WithMoney(Money);
            return accountBuilder;
        }

        public class AccountBuilder
        {
            private Client _owner;
            private float _credit;
            private Bank _accBank;
            private DateTime _date;
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
                var finalDepositAcc = new Account(_owner, _date, _accBank, _money);
                return finalDepositAcc;
            }
        }
    }
}
