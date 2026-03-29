using System.Runtime.InteropServices;
using Xunit;

public class IncomeTaxCalculatorTests
{   public double CalculateIncomeTax(double income)
    {

        if (income < 0) throw new ArgumentException("Income cannot be Negative");
        return 0;
        
    }
}
