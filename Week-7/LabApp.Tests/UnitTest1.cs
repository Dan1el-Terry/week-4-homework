namespace LabApp.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {

    }
}
public class IncomeTaxCalculatorTests

{

    [Theory]

    [InlineData(10000, 1000)]

    [InlineData(20000, 4000)]

    [InlineData(40000, 8000)]

    [InlineData(400000, 80000)]

    public void CalculateIncomeTax_ValidInput_ReturnsExpected(double income, double expectedTax)

    {

        var calculator = new IncomeTaxCalculator();

        var result = calculator.CalculateIncomeTax(income);

        Assert.Equal(expectedTax, result, 2);

    }

    [Fact]

    public void CalculateIncomeTax_NegativeIncome_Throws()

    {

        var calculator = new IncomeTaxCalculator();

        Assert.Throws<ArgumentException>(() => calculator.CalculateIncomeTax(-5));

    }

}

