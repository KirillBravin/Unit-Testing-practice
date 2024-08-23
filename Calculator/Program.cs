using System;

namespace Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Example usage of the Calculator class
            ICalculator calculator = new Calculator();
        }
    }

    public class Calculator : ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return Math.Round(a / b, 2);
        }
    }

    public interface ICalculator
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
        int Multiply(int a, int b);
        double Divide(double a, double b);
    }
}