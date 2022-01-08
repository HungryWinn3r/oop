using System.Collections.Generic;

namespace Banks
{
    public class TransferStory
    {
        public TransferStory()
        {
            TransactionAmount = new List<int>();
            Senders = new List<Account>();
            Recipients = new List<Account>();
        }

        public List<int> TransactionAmount { get; set; }

        public List<Account> Senders { get; set; }

        public List<Account> Recipients { get; set; }
    }
}