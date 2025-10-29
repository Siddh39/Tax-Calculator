using TaxCalculator.Class;

namespace MyTest1;

[TestClass]
public class TaxCalculationTest
{
    [TestMethod]
    public void CalculateTaxableAmount_TaxableAmount_RightAns()
    {
        // Arrange
        GetDetail details = new GetDetail();
        details.Income = 160000;
        details.Investment = 100000;
        details.HouseLoan = 10000;
        TaxCalculation taxCalculation = new TaxCalculation(details);
        double expected = 52000;

        // Act
        double taxableAmount = taxCalculation.CalculateTaxableAmount(details.Income, details.Investment, details.HouseLoan);

        // Assert
        Assert.AreEqual(expected, taxableAmount);
    }

    [TestMethod]
    public void ValidInvestment_ValidInvestment_GreaterThan1Lakh()
    {
        // Arrange
        GetDetail details = new GetDetail();
        details.Investment = 300000;
        TaxCalculation taxCalculation = new TaxCalculation(details);
        double expected = 100000;

        // Act
        double ans = taxCalculation.ValidInvestment(details.Investment);

        // Assert
        Assert.AreEqual(expected, ans);
    }

    [TestMethod]
    public void ValidInvestment_ValidInvestment_LessThan1Lakh()
    {
        // Arrange
        GetDetail details = new GetDetail();
        details.Investment = 80000;
        TaxCalculation taxCalculation = new TaxCalculation(details);
        double expected = 80000;

        // Act
        double ans = taxCalculation.ValidInvestment(details.Investment);

        // Assert
        Assert.AreEqual(expected, ans);
    }

    [TestMethod]
    public void FindExcluding_ExcludingAmount_IncomePercentGreater()
    {
        // Arrange
        GetDetail details = new GetDetail();
        details.Income = 160000;
        details.HouseLoan = 10000;
        TaxCalculation taxCalculation = new TaxCalculation(details);
        double expected = 8000;
        // Act
        double ans = taxCalculation.FindExcluding(details.HouseLoan, details.Income);
        // Assert
        Assert.AreEqual(expected, ans);
    }

    [TestMethod]
    public void FindExcluding_ExcludingAmount_IncomePercentLess()
    {
        // Arrange
        GetDetail details = new GetDetail();
        details.Income = 160000;
        details.HouseLoan = 100000;
        TaxCalculation taxCalculation = new TaxCalculation(details);
        double expected = 32000;

        // Act
        double ans = taxCalculation.FindExcluding(details.HouseLoan, details.Income);

        // Assert
        Assert.AreEqual(expected, ans);
    }

    [TestMethod]
    public void TaCalculateTax_Tax_TestCase1()
    {
        // Arrange
        GetDetail details = new GetDetail();
        details.Birthdate = Convert.ToDateTime("22/04/1965");
        details.age = GetDetail.CalculateAge(details.Birthdate);
        details.Gender = "Male";
        details.Income = 160000;
        details.Investment = 100000;
        details.HouseLoan = 10000;
        TaxCalculation taxCalculation = new TaxCalculation(details);
        double taxableAmount = taxCalculation.CalculateTaxableAmount(details.Income, details.Investment, details.HouseLoan);
        TaxSlabClassification taxSlab = new TaxSlabClassification();
        double expected = 0;

        // Act
        double ans = taxCalculation.CalculateTax(taxableAmount, taxSlab);

        // Assert
        Assert.AreEqual(expected, ans);
    }

    [TestMethod]
    public void TaCalculateTax_Tax_TestCase2()
    {
        // Arrange
        GetDetail details = new GetDetail();
        details.Birthdate = Convert.ToDateTime("22/04/1999");
        details.age = GetDetail.CalculateAge(details.Birthdate);
        details.Gender = "Male";
        details.Income = 1000000;
        details.Investment = 200000;
        details.HouseLoan = 160000;
        TaxCalculation taxCalculation = new TaxCalculation(details);
        double taxableAmount = taxCalculation.CalculateTaxableAmount(details.Income, details.Investment, details.HouseLoan);
        TaxSlabClassification taxSlab = new TaxSlabClassification();
        double expected = 135600;

        // Act
        double ans = taxCalculation.CalculateTax(taxableAmount, taxSlab);

        // Assert
        Assert.AreEqual(expected, ans);
    }

    [TestMethod]
    public void TaCalculateTax_Tax_TestCase3()
    {
        // Arrange
        GetDetail details = new GetDetail();
        details.Birthdate = Convert.ToDateTime("22/04/1979");
        details.age = GetDetail.CalculateAge(details.Birthdate);
        details.Gender = "Female";
        details.Income = 1000000;
        details.Investment = 200000;
        details.HouseLoan = 160000;
        TaxCalculation taxCalculation = new TaxCalculation(details);
        double taxableAmount = taxCalculation.CalculateTaxableAmount(details.Income, details.Investment, details.HouseLoan);
        TaxSlabClassification taxSlab = new TaxSlabClassification();
        double expected = 132600;

        // Act
        double ans = taxCalculation.CalculateTax(taxableAmount, taxSlab);

        // Assert
        Assert.AreEqual(expected, ans);
    }

    [TestMethod]
    public void TaCalculateTax_Tax_TestCase4()
    {
        // Arrange
        GetDetail details = new GetDetail();
        details.Birthdate = Convert.ToDateTime("22/04/1963");
        details.age = GetDetail.CalculateAge(details.Birthdate);
        details.Gender = "Female";
        details.Income = 1000000;
        details.Investment = 1000000;
        details.HouseLoan = 0;
        TaxCalculation taxCalculation = new TaxCalculation(details);
        double taxableAmount = taxCalculation.CalculateTaxableAmount(details.Income, details.Investment, details.HouseLoan);
        TaxSlabClassification taxSlab = new TaxSlabClassification();
        double expected = 166000;

        // Act
        double ans = taxCalculation.CalculateTax(taxableAmount, taxSlab);

        // Assert
        Assert.AreEqual(expected, ans);
    }
    [TestMethod]
    public void TaCalculateTax_Tax_TestCase5()
    {
        // Arrange
        GetDetail details = new GetDetail();
        details.Birthdate = Convert.ToDateTime("22/04/1959");
        details.age = GetDetail.CalculateAge(details.Birthdate);
        details.Gender = "Female";
        details.Income = 450000;
        details.Investment = 0;
        details.HouseLoan = 0;
        TaxCalculation taxCalculation = new TaxCalculation(details);
        double expected = 36000;

        // Act
        double taxableAmount = taxCalculation.CalculateTaxableAmount(details.Income, details.Investment, details.HouseLoan);
        TaxSlabClassification taxSlab = new TaxSlabClassification();
        double ans = taxCalculation.CalculateTax(taxableAmount, taxSlab);

        // Assert
        Assert.AreEqual(expected, ans);
    }
}
