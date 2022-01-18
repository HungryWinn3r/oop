namespace Shops
{
    public class Shop
    {
        public Shop(string name, int id, string address)
        {
            Name = name;
            Id = id;
            Address = address;
        }

        public string Name { get; }

        public int Id { get; }

        public string Address { get; }
    }
}
