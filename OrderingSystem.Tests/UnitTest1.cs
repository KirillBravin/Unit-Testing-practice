using OrderingSystem;
using static OrderingSystem.Program;

namespace OrderingSystem.Tests
{
    public class OrderTests
    {
        [Fact]
        public void TestAddingItems()
        {
            //Arrange
            IOrderingSystemService orderingSystem = new OrderingSystemService();
            string itemName = "VideoGame";
            int quantity = 3;
            decimal price = 22m;
            //Act
            bool newOrder = orderingSystem.AddItem(itemName, quantity, price);
            //Assert
            Assert.True(newOrder);
        }

        [Fact]
        public void TestRemovingItems()
        {
            //Arrange
            IOrderingSystemService orderingSystem = new OrderingSystemService();
            string itemName = "VideoGame";
            int quantity = 3;
            decimal price = 22m;
            //Act
            orderingSystem.AddItem(itemName, quantity, price);
            bool itemRemoved = orderingSystem.RemoveItem(itemName);
            var allOrders = orderingSystem.GetAllOrders();
            //Assert
            Assert.True(itemRemoved);
            Assert.DoesNotContain(allOrders, order => order.ItemName == itemName);
        }

        [Fact]
        public void TestTotalAmountCalculation()
        {
            //Arrange
            IOrderingSystemService orderingSystem = new OrderingSystemService();
            string itemName1 = "Witcher 3";
            int quantity1 = 1;
            decimal price1 = 22.3m;
            string itemName2 = "Red Dead Redemption 2";
            int quantity2 = 1;
            decimal price2 = 30m;
            decimal expectedResult = 22.3m + 30m;
            //Act
            orderingSystem.AddItem(itemName1, quantity1, price1);
            orderingSystem.AddItem(itemName2, quantity2, price2);
            decimal actualPrice = orderingSystem.GetTotalAmount();
            //Assert
            Assert.Equal(expectedResult, actualPrice);
        }

        [Fact]
        public void TestDiscount()
        {
            //Arrange
            IOrderingSystemService orderingSystem = new OrderingSystemService();
            orderingSystem.AddItem("Laptop", 1, 1000m);
            orderingSystem.AddItem("Mouse", 2, 50m);

            decimal discountPercentage = 10m;
            decimal expectedFinalAmount = 990m;

            //Act
            decimal actualFinalAmount = orderingSystem.ApplyDiscount(discountPercentage);

            //Assert
            Assert.Equal(expectedFinalAmount, actualFinalAmount);
        }

        [Fact]
        public void TestGetAllOrders()
        {
            // Arrange
            IOrderingSystemService orderingSystem = new Program.OrderingSystemService();
            orderingSystem.AddItem("Laptop", 1, 1000m);
            orderingSystem.AddItem("Mouse", 2, 50m);

            var expectedOrders = new List<Order>
            {
                new Order("Laptop", 1, 1000m),
                new Order("Mouse", 2, 50m)
            };

            // Act
            var actualOrders = orderingSystem.GetAllOrders();

            // Assert
            Assert.Equal(expectedOrders.Count, actualOrders.Count);
            for (int i = 0; i < expectedOrders.Count; i++)
            {
                Assert.Equal(expectedOrders[i].ItemName, actualOrders[i].ItemName);
                Assert.Equal(expectedOrders[i].Quantity, actualOrders[i].Quantity);
                Assert.Equal(expectedOrders[i].Price, actualOrders[i].Price);
            }
        }
    }
}