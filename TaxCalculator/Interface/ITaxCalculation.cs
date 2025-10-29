namespace TaxCalculator
{
    internal interface ITaxCalculation
    {
        public double ValidInvestment(double investment);

        public double FindExcluding(double houseLoan, double income);
    }
}
