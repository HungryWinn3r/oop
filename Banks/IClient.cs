namespace Banks
{
    public interface IClient
    {
        Client AddClient(string name, string surname, string address, string passport);
        void ChangeAddressClient(Client client, string address);
        void ChangePassportClient(Client client, string passport);
    }
}
