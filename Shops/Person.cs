namespace Shops
{
    public class Person
    {
        public Person(string name, int money, int id)
        {
            Name = name;
            Money = money;
            Id = id;
        }

        public string Name { get; }

        public int Money { get; }

        public int Id { get; }

        public PersonBuilder ToBuilder()
        {
            var personBuilder = new PersonBuilder();
            personBuilder.WithName(Name);
            personBuilder.WithMoney(Money);
            personBuilder.WithId(Id);
            return personBuilder;
        }

        public class PersonBuilder
        {
            private string _name;
            private int _money;
            private int _id;

            public PersonBuilder WithName(string name)
            {
                _name = name;
                return this;
            }

            public PersonBuilder WithMoney(int money)
            {
                _money = money;
                return this;
            }

            public PersonBuilder WithId(int id)
            {
                _id = id;
                return this;
            }

            public Person Build()
            {
                var finalPerson = new Person(_name, _money, _id);
                return finalPerson;
            }
        }
    }
}
