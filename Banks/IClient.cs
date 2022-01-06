namespace Banks
{
    public interface IClient
    {
        public Client AddClient(string name, string surname, string address, int passport);
        public Client AddClient(string name, string surname);
        public Client AddClient(string name, string surname, string address);
        public Client AddClient(string name, string surname, int passport);
        public void ChangeAddressClient(Client client, string address);
        public void ChangePassportClient(Client client, int passport);
    }
}
