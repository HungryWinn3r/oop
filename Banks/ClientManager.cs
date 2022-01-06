namespace Banks
{
    public class ClientManager : IClient
    {
        public Client AddClient(string name, string surname, string address, int passport)
        {
            var newClient = new Client(name, surname, address, passport);
            return newClient;
        }

        public Client AddClient(string name, string surname)
        {
            var newClient = new Client(name, surname);
            return newClient;
        }

        public Client AddClient(string name, string surname, int passport)
        {
            var newClient = new Client(name, surname, passport);
            return newClient;
        }

        public Client AddClient(string name, string surname, string address)
        {
            var newClient = new Client(name, surname, address);
            return newClient;
        }

        public void ChangeAddressClient(Client client, string address)
        {
            client.ToBuilder().WithAddress(address).BuildClient();
            client.Level++;
        }

        public void ChangePassportClient(Client client, int passport)
        {
            client.ToBuilder().WithPassport(passport).BuildClient();
            client.Level++;
        }
    }
}
