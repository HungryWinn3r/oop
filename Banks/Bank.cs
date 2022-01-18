using System.Collections.Generic;

namespace Banks
{
    public class Bank
    {
        public Bank(float percentForDebit, float percentForDeposit, float commission, float limitForTrans)
        {
            PercentForDebit = percentForDebit;
            PercentForDebitPerDay = percentForDebit / 365;
            PercentForDeposit = percentForDeposit;
            PercentForDepositPerDay = percentForDeposit / 365;
            Commission = commission;
            CommissionPerDay = commission / 365;
            ClientsInBank = new List<Client>();
            AccountsInBank = new List<Account>();
            Id = IdMaker.MakeId();
            LimitForTrans = limitForTrans;
            DebitFollowers = new List<Client>();
            DepositFollowers = new List<Client>();
            CreditFollowers = new List<Client>();
        }

        public float LimitForTrans { get; }

        public float PercentForDebitPerDay { get; }

        public float PercentForDepositPerDay { get; }

        public float CommissionPerDay { get; }

        public float PercentForDebit { get; }

        public float PercentForDeposit { get; }

        public float Commission { get; }

        public int Id { get; }

        public List<Account> AccountsInBank { get; }

        public List<Client> ClientsInBank { get; }

        public List<Client> DebitFollowers { get; }

        public List<Client> DepositFollowers { get; }

        public List<Client> CreditFollowers { get; }

        public BankBuilder ToBuilder()
        {
            var bankBuilder = new BankBuilder();
            bankBuilder.WithLimitForTrans(LimitForTrans);
            bankBuilder.WithCommission(Commission);
            bankBuilder.WithPercentForDeposit(PercentForDeposit);
            bankBuilder.WithPercentForDebit(PercentForDebit);
            return bankBuilder;
        }

        public class BankBuilder
        {
            private float _limitForTrans;
            private float _commission;
            private float _percentForDeposit;
            private float _percentForDebit;

            public BankBuilder WithLimitForTrans(float limitForTrans)
            {
                _limitForTrans = limitForTrans;
                return this;
            }

            public BankBuilder WithCommission(float commission)
            {
                _commission = commission;
                return this;
            }

            public BankBuilder WithPercentForDeposit(float percentForDeposit)
            {
                _percentForDeposit = percentForDeposit;
                return this;
            }

            public BankBuilder WithPercentForDebit(float percentForDebit)
            {
                _percentForDebit = percentForDebit;
                return this;
            }

            public Bank Build()
            {
                var finalBank = new Bank(_percentForDebit, _percentForDeposit, _commission, _limitForTrans);
                return finalBank;
            }
        }
    }
}
