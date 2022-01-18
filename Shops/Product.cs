namespace Shops
{
    public class Product
    {
        public Product(int shopId, string productName, int price, int count)
        {
            ShopId = shopId;
            Name = productName;
            Price = price;
            Count = count;
        }

        public Product(string productName, int count)
        {
            Name = productName;
            Count = count;
        }

        public string Name { get; }

        public int ShopId { get; }

        public int Price { get; }

        public int Count { get; }

        public ProductBuilder ToBuilder()
        {
            var productBuilder = new ProductBuilder();
            productBuilder.WithName(Name);
            productBuilder.WithShopId(ShopId);
            productBuilder.WithPrice(Price);
            productBuilder.WithCount(Count);
            return productBuilder;
        }

        public class ProductBuilder
        {
            private int _shopId;
            private string _name;
            private int _price;
            private int _count;

            public ProductBuilder WithShopId(int shopId)
            {
                _shopId = shopId;
                return this;
            }

            public ProductBuilder WithName(string name)
            {
                _name = name;
                return this;
            }

            public ProductBuilder WithPrice(int price)
            {
                _price = price;
                return this;
            }

            public ProductBuilder WithCount(int count)
            {
                _count = count;
                return this;
            }

            public Product Build()
            {
                var finalProduct = new Product(_shopId, _name, _price, _count);
                return finalProduct;
            }
        }
    }
}
