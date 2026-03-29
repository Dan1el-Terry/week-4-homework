public class IncomeTaxCalculator
{
    public double CalculateIncomeTax(double income)
    {
        if (income < 0) throw new ArgumentException("Insert a number above 0");
               
    
        if (income <= 14000)
            return income * 0.10;
        else if (income> 14000)
            return income * 0.20;
        else if (income > 400000)
            return income * 0.99;
        return 0;

    }
}
