using Calculator;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void TestAdd()
        {
            ICalculator calculator = new Calculator();
            int a = 5;
            int b = 3;
            int result = 8;

            int actualResult = calculator.Add(a, b);
            Assert.Equal(result, actualResult);
        }

        [Fact]
        public void TestSubtract()
        {
            ICalculator calculator = new Calculator();
            int a = 10;
            int b = 2;
            int result = 8;

            int actualResult = calculator.Subtract(a, b);
            Assert.Equal(result, actualResult);
        }

        [Fact]
        public void TestMultiply()
        {
            ICalculator calculator = new Calculator();
            int a = 3;
            int b = 2;
            int result = 6;

            int actualResult = calculator.Multiply(a, b);
            Assert.Equal(result, actualResult);
        }

        [Fact]
        public void TestDivide()
        {
            ICalculator calculator = new Calculator();
            int a = 3;
            int b = 0;

            Assert.Throws<DivideByZeroException>(() => calculator.Divide(a, b));
        }
    }
}