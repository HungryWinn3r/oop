using System.Collections.Generic;

namespace Shops.Services
{
    public interface IShopService
    {
        Shop AddShop(string name, string address);
        Product AddProduct(string productName, int count);
        void AddProductsToShop(Shop shop, List<Product> products);
        Person AddCustomer(string name, int money);
        void ChangeThePrice(Product product, int curPrice);
        Shop GetShop(int shopId);
        Product FindProductByName(string productName);
        Product FindProductByNameAndShop(string productName, int id);
        Person FindCustomer(string name);
        List<Product> FindProducts(Shop shop);
        int CalculatePriceAtShop(Shop shop, List<Product> products);
        int FindCheapest(List<Product> products);
        void BuyProducts(Person person, Shop shop, int count, List<Product> products);
    }
}
