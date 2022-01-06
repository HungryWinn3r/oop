namespace Banks
{
    public class Client : IClient
    {
        public Client(string name, string surname, string address, int passport)
        {
            Name = name;
            Surname = surname;
            Address = address;
            Passport = passport;
            Level = 3;
            Message = "0";
        }

        public Client(string name, string surname, string address)
        {
            Name = name;
            Surname = surname;
            Address = address;
            Passport = 0;
            Level = 2;
            Message = "0";
        }

        public Client(string name, string surname, int passport)
        {
            Name = name;
            Surname = surname;
            Address = "0";
            Passport = passport;
            Level = 2;
            Message = "0";
        }

        public Client(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Address = "0";
            Passport = 0;
            Level = 1;
            Message = "0";
        }

        public string Message { get; set; }

        public string Address { get; }

        public int Passport { get; }

        public int Level { get; set; }

        public string Name { get; }

        public string Surname { get; }

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

        public ClientBuilder ToBuilder()
        {
            var clientBuilder = new ClientBuilder();
            clientBuilder.WithAddress(Address);
            clientBuilder.WithSurname(Surname);
            clientBuilder.WithPassport(Passport);
            clientBuilder.WithName(Name);
            return clientBuilder;
        }

        public class ClientBuilder
        {
            private string _address;
            private string _surname;
            private int _passport;
            private string _name;

            public ClientBuilder WithAddress(string address)
            {
                _address = address;
                return this;
            }

            public ClientBuilder WithSurname(string surname)
            {
                _surname = surname;
                return this;
            }

            public ClientBuilder WithPassport(int passport)
            {
                _passport = passport;
                return this;
            }

            public ClientBuilder WithName(string name)
            {
                _name = name;
                return this;
            }

            public Client BuildClient()
            {
                var finalClient = new Client(_name, _surname, _address, _passport);
                return finalClient;
            }

            public Client BuildLowLevelClient()
            {
                var finalClient = new Client(_name, _surname);
                return finalClient;
            }

            public Client BuildLowLevelWithAddressClient()
            {
                var finalClient = new Client(_name, _surname, _address);
                return finalClient;
            }

            public Client BuildLowLevelWithPassportClient()
            {
                var finalClient = new Client(_name, _surname, _passport);
                return finalClient;
            }
        }
    }
}
