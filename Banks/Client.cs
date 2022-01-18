namespace Banks
{
    public class Client
    {
        public Client(string name, string surname, string address, string passport)
        {
            Name = name;
            Surname = surname;
            Address = address;
            Passport = passport;
            Message = "0";
        }

        public string Message { get; set; }

        public string Address { get; }

        public string Passport { get; }

        public string Name { get; }

        public string Surname { get; }

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
            private string _passport;
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

            public ClientBuilder WithPassport(string passport)
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
        }
    }
}
