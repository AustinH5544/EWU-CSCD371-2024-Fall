using Calculate;

namespace Calculate.Tests;

[TestClass]
public class CalculatorTests
{
    [TestMethod]
    [DataRow(5, 10)]
    [DataRow(5.0, 10)]
    [DataRow(0,0.1)]
    [DataRow((float)1200,2.5)]
    [DataRow(0.00, 0)]
    public void Add_TwoNumbers_ReturnsSum<T>(T genericNum1, T genericNum2) where T : IConvertible
    {
        // Arrange

        double num1 = Convert.ToDouble(genericNum1);
        double num2 = Convert.ToDouble(genericNum1);
        // Act
        Calculator.Add(genericNum1, genericNum2, out double result);
        // Assert
        Assert.AreEqual(num1+num2, result);
    }

    [TestMethod]
    [DataRow(5, 10)]
    [DataRow((float)5.0, 10)]
    [DataRow(0, 0.1)]
    [DataRow(1200, 2.5)]
    [DataRow(0.00, 0)]
    public void Subtract_TwoNumbers_ReturnsDifference<T>(T genericNum1, T genericNum2) where T : IConvertible
    {
        // Arrange

        double num1 = Convert.ToDouble(genericNum1);
        double num2 = Convert.ToDouble(genericNum2);

        // Act
        Calculator.Subtract(genericNum1, genericNum2, out double result);

        // Assert
        Assert.AreEqual(num1-num2, result);
    }

    [TestMethod]
    [DataRow(5, 10)]
    [DataRow(5.0, 10)]
    [DataRow(0, 0.1)]
    [DataRow(1200, (float)2.5)]
    [DataRow(0.00, 0)]
    public void Multiply_TwoNumbers_ReturnsProduct<T>(T genericNum1, T genericNum2) where T : IConvertible
    {
        // Arrange
        double num1 = Convert.ToDouble(genericNum1);
        double num2 = Convert.ToDouble(genericNum2);

        // Act
        Calculator.Multiply(genericNum1, genericNum2, out double result);

        // Assert
        Assert.AreEqual(num1 * num2, result);
    }

    [TestMethod]
    [DataRow(5, 10)]
    [DataRow(5.0, 10)]
    [DataRow(0, 0.1)]
    [DataRow((float)1200, (float)2.5)]
    public void Divide_TwoNumbers_ReturnsQuotient<T>(T genericNum1, T genericNum2) where T : IConvertible
    {
        
        // Arrange
        double num1 = Convert.ToDouble(genericNum1);
        double num2 = Convert.ToDouble(genericNum2);

        // Act
        Calculator.Divide(genericNum1, genericNum2, out double result);

        // Assert
        Assert.AreEqual(num1/num2, result);
    }

    [TestMethod]
    [DataRow(5, 0)]
    [DataRow(5.0, 0.0)]
    [DataRow(0, (float) 0.0)]
    [DataRow((float)1200, 0)]
    public void Divide_ByZero_ThrowsException<T>(T genericNum1, T genericNum2) where T : IConvertible
    {
        // Arrange
        double num1 = Convert.ToDouble(genericNum1);
        double num2 = Convert.ToDouble(genericNum2);

        // Act and Assert
        Assert.ThrowsException<DivideByZeroException>(() => Calculator.Divide(genericNum1, genericNum2, out double result));
    }


    [TestMethod]
    public void Dictionary_Should_Contain_All_Operations()
    {
        var calculator = new Calculator();

        Assert.IsTrue(calculator.MathematicalOperations.ContainsKey('+'));
        Assert.IsTrue(calculator.MathematicalOperations.ContainsKey('-'));
        Assert.IsTrue(calculator.MathematicalOperations.ContainsKey('*'));
        Assert.IsTrue(calculator.MathematicalOperations.ContainsKey('/'));
    }

    [TestMethod]
    public void Addition_Should_Return_Correct_Result()
    {
        var calculator = new Calculator();

        calculator.MathematicalOperations['+'](5, 3, out double result);

        Assert.AreEqual(8.0, result);
    }

    [TestMethod]
    public void Subtraction_Should_Return_Correct_Result()
    {
        var calculator = new Calculator();

        calculator.MathematicalOperations['-'](5, 3, out double result);

        Assert.AreEqual(2.0, result);
    }

    [TestMethod]
    public void Multiplication_Should_Return_Correct_Result()
    {
        var calculator = new Calculator();

        calculator.MathematicalOperations['*'](5, 3, out double result);

        Assert.AreEqual(15.0, result);
    }

    [TestMethod]
    public void Division_Should_Return_Correct_Result()
    {
        var calculator = new Calculator();

        calculator.MathematicalOperations['/'](6, 3, out double result);

        Assert.AreEqual(2.0, result);
    }
}