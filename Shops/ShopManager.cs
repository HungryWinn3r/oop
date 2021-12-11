using System;
using System.Collections.Generic;
using Shops.Services;

namespace Shops
{
    public class ShopManager : IShopService
    {
        private readonly List<Shop> allShops = new List<Shop>();
        private List<Person> allCustomers = new List<Person>();
        private List<Product> allProducts = new List<Product>();

        public Shop AddShop(string name, string address)
        {
            var newShop = new Shop(name, IdMaker.MakeId(), address);
            allShops.Add(newShop);
            return newShop;
        }

        public Product AddProduct(string productName, int count)
        {
            var newProduct = new Product(productName, count);
            allProducts.Add(newProduct);
            return newProduct;
        }

        public void AddProductsToShop(Shop shop, List<Product> products)
        {
            foreach (Product product in products)
            {
                Product newProduct = product.ToBuilder().WithShopId(shop.Id).Build();
                allProducts.Remove(product);
                allProducts.Add(newProduct);
            }
        }

        public Person AddCustomer(string name, int money)
        {
            var newCustomer = new Person(name, money);
            allCustomers.Add(newCustomer);
            return newCustomer;
        }

        public void ChangeThePrice(Product product, int curPrice)
        {
            Product newProduct = product.ToBuilder().WithPrice(curPrice).Build();
            allProducts.Remove(product);
            allProducts.Add(newProduct);
        }

        public Shop GetShop(int shopId)
        {
            return allShops.Find(shop => shop.Id == shopId);
        }

        public Product FindProductByName(string productName)
        {
            return allProducts.Find(product => product.Name == productName);
        }

        public Product FindProductByNameAndShop(string productName, int id)
        {
            return allProducts.Find(product => product.Name == productName && product.ShopId == id);
        }

        public Person FindCustomer(string name)
        {
            return allCustomers.Find(person => person.Name == name);
        }

        public List<Product> FindProducts(Shop shop)
        {
            return allProducts.FindAll(product => product.ShopId == shop.Id);
        }

        public int CalculatePriceAtShop(Shop shop, List<Product> products)
        {
            int sum = 0;
            foreach (Product product in products)
            {
                Product foundedProduct = FindProducts(shop).Find(obj => obj.Name == product.Name);
                if (foundedProduct == null)
                {
                    return int.MaxValue;
                }

                if (foundedProduct.Count < product.Count)
                {
                    return int.MaxValue;
                }

                sum += product.Count * foundedProduct.Price;
            }

            return sum;
        }

        public int FindCheapest(List<Product> products)
        {
            int cheapestShopId = 0;
            int cheapProd = int.MaxValue;
            int sum;

            foreach (Shop shop in allShops)
            {
                sum = CalculatePriceAtShop(shop, products);
                if (sum < cheapProd)
                {
                    cheapProd = sum;
                    cheapestShopId = shop.Id;
                }
            }

            return cheapestShopId;
        }

        public void BuyProducts(Person person, Shop shop, int count, List<Product> products)
        {
            int sum = 0;
            List<Product> products1 = allProducts;

            foreach (Product product in products)
            {
                Product productInShop = FindProducts(shop).Find(obj => obj.Name == product.Name);
                if (productInShop == null)
                {
                    throw new Exception("not found");
                }

                if (productInShop.Count >= count)
                {
                    sum += productInShop.Price * count;
                    Product newProduct = productInShop.ToBuilder().WithCount(productInShop.Count - count).Build();
                    products1.Remove(productInShop);
                    products1.Add(newProduct);
                }
            }

            if (person.Money >= sum)
            {
                allProducts = products1;
                Person newPerson = person.ToBuilder().WithMoney(person.Money - sum).Build();
                allCustomers.Remove(person);
                allCustomers.Add(newPerson);
            }
            else
            {
                throw new Exception("not enough money");
            }
        }
    }
}
