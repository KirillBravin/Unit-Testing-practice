using System;

namespace OrderingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }

        public class OrderingSystemService() : IOrderingSystemService
        {
            List<Order> orders = new List<Order>();
            public bool AddItem(string itemName, int quantity, decimal price)
            {
                var order = orders.FirstOrDefault(x => x.ItemName == itemName);
                if (order != null)
                {
                    return false;
                }
                else
                {
                    orders.Add(new Order(itemName, quantity, price));
                    return true;
                }
            }

            public bool RemoveItem(string itemName)
            {
                var order = orders.FirstOrDefault(x => x.ItemName == itemName);
                if (order != null)
                {
                    orders.Remove(order);
                    return true;
                }
                else return false;
            }

            public decimal GetTotalAmount()
            {
                return orders.Sum(order => order.Quantity * order.Price);
            }

            public List<Order> GetAllOrders()
            {
                return orders;
            }

            public decimal ApplyDiscount(decimal discountPercentage)
            {
                decimal totalAmount = GetTotalAmount();
                decimal discountAmount = totalAmount * (discountPercentage / 100);
                decimal finalAmount = totalAmount - discountAmount;
                return finalAmount;
            }
        }
    }

    public interface IOrderingSystemService
    {
        bool AddItem(string itemName, int quantity, decimal price);
        bool RemoveItem(string itemName);
        decimal GetTotalAmount();
        decimal ApplyDiscount(decimal discountPercentage);
        List<Order> GetAllOrders();
    }
}