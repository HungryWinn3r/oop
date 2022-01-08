using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.Tests
{
    public class BankTests
    {
        private ICentralBank _centralBank;
        private IAccount _account;
        private IClient _client;
        private IBank _bank;

        [SetUp]
        public void Setup()
        {
            _centralBank = new CentralBank();
            _account = new AccountManager();
            _client = new ClientManager();
            _bank = new BankManager();
        }

        [Test]
        public void Transaction_MoneyBack()
        {
            Client client = _client.AddClient("name", "surname");
            Bank bank = _centralBank.AddBank(1, 1, 1, 1000);
            Account account = _account.AddDebitAccount(client, bank, 0);
            _account.AddMoneyToDebitAcc(account, 10000);
            Account account1 = _account.AddDebitAccount(client, bank, 100);
            _centralBank.TransferMoney(account1, account, 500);
            _centralBank.MoneyBack(account, account1);
            int expectedMoney = 100;
            Assert.AreEqual(expectedMoney, account1.Money);
        }

        [Test]
        public void TransferMoney_MoneyTransfered()
        {
            Client client = _client.AddClient("name", "surname", "232", 12);
            Bank bank = _centralBank.AddBank(1, 1, 1, 1000);
            Account account = _account.AddDebitAccount(client, bank, 1);
            int expectedMoney = 1;
            Assert.AreEqual(expectedMoney, account.Money);
        }

        [Test]
        public void AddMoneyToAcc()
        {
            Client client = _client.AddClient("name", "surname", "232", 12);
            Bank bank = _centralBank.AddBank(1, 1, 1, 1000);
            Account account = _account.AddDebitAccount(client, bank, 1);
            Account account1 = _account.AddCreditAccount(client, 555, bank);
            _account.AddMoneyToCreditAcc(account1, 2);
            int expectedMoney = 3;
            Assert.AreEqual(expectedMoney, account1.Money);
        }
    }
}

