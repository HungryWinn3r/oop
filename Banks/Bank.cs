using System;
using System.Collections.Generic;
using System.Text;

namespace Banks
{
    public class Bank
    {
        public Bank(float percentForDebit, float percentForDeposit, float commission)
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
        }

        public float PercentForDebitPerDay { get; }

        public float PercentForDepositPerDay { get; }

        public float CommissionPerDay { get; }

        public float PercentForDebit { get; }

        public float PercentForDeposit { get; }

        public float Commission { get; }

        public int Id { get; }

        public List<Account> AccountsInBank { get; }

        public List<Client> ClientsInBank { get; }
    }
}
