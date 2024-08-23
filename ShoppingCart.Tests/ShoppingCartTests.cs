using ShoppingCart;

namespace ShoppingCart.Tests
{
    public class ShoppingCartTests
    {
        [Fact]
        public void TestAddingItemToCart()
        {
            //Arrange
            IShoppingCartService shoppingService = new ShoppingCartService();
            string itemName = "Oranges";
            int quantity = 200;
            decimal price = 22.3m;
            //Act
            bool shoppingItem = shoppingService.AddItem(itemName, quantity, price);
            //Assert
            Assert.True(shoppingItem);
        }

        [Fact]
        public void TestItemRemoval()
        {
            //Arrange
            IShoppingCartService shoppingService = new ShoppingCartService();
            List<Product> products = new List<Product>();
            string itemName = "Oranges";
            int quantity = 200;
            decimal price = 22.3m;
            //Act
            shoppingService.AddItem(itemName, quantity, price);
            bool itemRemoved = shoppingService.DeleteItem(itemName);
            var items = shoppingService.GetProducts();
            //Assert
            Assert.True(itemRemoved);
            Assert.DoesNotContain(items, item => item.ItemName == itemName);
        }

        [Fact]
        public void TestTotalPrice()
        {
            //Arrange
            IShoppingCartService shoppingService = new ShoppingCartService();
            string itemName1 = "Oranges";
            int quantity1 = 200;
            decimal price1 = 22.3m;
            string itemName2 = "Bananas";
            int quantity2 = 10;
            decimal price2 = 10m;
            decimal expectedResult = 4460m + 100m;
            //Act
            shoppingService.AddItem(itemName1, quantity1, price1);
            shoppingService.AddItem(itemName2, quantity2, price2);
            decimal actualPrice = shoppingService.GetTotalPrice();
            //Assert
            Assert.Equal(expectedResult, actualPrice);
        }

        [Fact]
        public void TestItemListReturn()
        {
            //Arrange
            IShoppingCartService shoppingService = new ShoppingCartService();
            //Act
            shoppingService.AddItem("Oranges", 200, 30m);
            shoppingService.AddItem("Bananas", 100, 10m);
            List<Product> allProducts = shoppingService.GetProducts();
            //Assert
            Assert.Equal(2, allProducts.Count);
            Assert.Contains(allProducts, p => p.ItemName == "Oranges" && p.Quantity == 200 && p.Price == 30m);
            Assert.Contains(allProducts, p => p.ItemName == "Bananas" && p.Quantity == 100 && p.Price == 10m);
        }
    }
}