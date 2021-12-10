using NUnit.Framework;
using Shops.Services;
using System.Collections.Generic;

namespace Shops.Tests
{
    public class ShopManagerTest
    {

        private IShopService _shopManager;

        [SetUp]
        public void Setup()
        {
            _shopManager = new ShopManager();
        }

        [Test]
        public void AddProductToShop_ShopContainsProduct()
        {
            Shop shop = _shopManager.AddShop("shop", "address");
            Product product = _shopManager.AddProduct("apple", 2);
            var list = new List<Product>();
            list.Add(product);
            _shopManager.AddProductsToShop(shop, list);
            Assert.Contains(product, list);
        }

        [Test]
        public void ChangeThePrice_PriceChanged()
        {
            Shop shop = _shopManager.AddShop("shop", "address");
            Product product = _shopManager.AddProduct("apple", 2);
            var list = new List<Product>();
            list.Add(product);
            int expPrice = 24;
            _shopManager.AddProductsToShop(shop, list);
            _shopManager.ChangeThePrice(_shopManager.FindProductByName(product.Name), 24);
            int foundedProd = _shopManager.FindProductByName(product.Name).Price;
            Assert.AreEqual(expPrice, foundedProd);
        }

        [Test]
        public void FindCheapestShop()
        {
            Shop shop = _shopManager.AddShop("shop", "address");
            Shop shop1 = _shopManager.AddShop("shop1", "address1");
            Product product = _shopManager.AddProduct("apple", 20);
            Product product1 = _shopManager.AddProduct("apple", 20);
            var list = new List<Product>();
            list.Add(product);
            var list1 = new List<Product>();
            list1.Add(product1);
            _shopManager.AddProductsToShop(shop, list);
            _shopManager.AddProductsToShop(shop1, list1);
            _shopManager.ChangeThePrice(_shopManager.FindProductByNameAndShop(product.Name, shop.Id), 20);
            _shopManager.ChangeThePrice(_shopManager.FindProductByNameAndShop(product1.Name, shop1.Id), 120);
            var list3 = new List<Product>();
            list3.Add(product);
            list3.Add(product1);
            Assert.AreEqual(shop.Id, _shopManager.FindCheapest(list3));
        }

        [Test]
        public void BuyProducts_CustomerMoneyAndCountProductsAtShopChanged()
        {
            Shop shop = _shopManager.AddShop("shop", "address");
            Product product = _shopManager.AddProduct("apple", 10);
            Product product1 = _shopManager.AddProduct("orange", 15);
            var list = new List<Product>();
            list.Add(product);
            list.Add(product1);
            _shopManager.AddProductsToShop(shop, list);
            _shopManager.ChangeThePrice(_shopManager.FindProductByNameAndShop(product.Name, shop.Id), 20);
            _shopManager.ChangeThePrice(_shopManager.FindProductByNameAndShop(product1.Name, shop.Id), 50);
            Person person = _shopManager.AddCustomer("Person", 12345);
            _shopManager.BuyProducts(person, shop, 3, list);
            int expectedPersonMoney = 12345 - 3 * 20 - 3 * 50;
            Assert.AreEqual(expectedPersonMoney, _shopManager.FindCustomer("Person").Money);
        }
    }
}