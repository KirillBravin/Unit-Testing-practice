using System;
using ShoppingCart;

namespace ShoppingCart
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }
    }

    public class ShoppingCartService() : IShoppingCartService
    {
        List<Product> products = new List<Product>();

        public bool AddItem(string itemName, int quantity, decimal price)
        {
            var product = products.FirstOrDefault(x => x.ItemName == itemName);
            if (product != null)
            {
                return false;
            }
            else
            {
                products.Add(new Product(itemName, quantity, price));
                return true;
            }
        }

        public bool DeleteItem(string itemName)
        {
            var product = products.FirstOrDefault(x => x.ItemName == itemName);
            if (product == null)
            {
                return false;
            }
            else
            {
                products.Remove(product);
                return true;
            }
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = products.Sum(product => product.Price * product.Quantity);
            return totalPrice;
        }

        public List<Product> GetProducts()
        {
            return products;
        }
    }

    public interface IShoppingCartService
    {
        bool AddItem(string itemName, int quantity, decimal price);
        bool DeleteItem(string itemName);
        decimal GetTotalPrice();
        List<Product> GetProducts();
    }
}