namespace Banks
{
    public class ClientManager : IClient
    {
        public Client AddClient(string name, string surname, string address, string passport)
        {
            var newClient = new Client(name, surname, address, passport);
            return newClient;
        }

        public void ChangeAddressClient(Client client, string address)
        {
            client.ToBuilder().WithAddress(address).BuildClient();
        }

        public void ChangePassportClient(Client client, string passport)
        {
            client.ToBuilder().WithPassport(passport).BuildClient();
        }
    }
}
