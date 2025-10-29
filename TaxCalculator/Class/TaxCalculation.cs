
using TaxCalculator.Resource;

namespace TaxCalculator.Class
{
    public class TaxCalculation : ITaxCalculation
    {
        GetDetail _personalDetails;
        /// <summary>
        /// This is Constructor to assign value to Private Object
        /// </summary>
        /// <param name="personDetails"> This is object of Person Details to access the Members of PersonDetails Class</param>
        public TaxCalculation(GetDetail allInputs)
        {
            _personalDetails = allInputs;
        }
        /// <summary>
        /// This function is used to find The Taxable Amount by subtracting Valid Investment and Excluding Amount
        /// </summary>
        /// <param name="income"></param>
        /// <param name="investment"></param>
        /// <param name="houseLoan"></param>
        /// <returns>Taxable Amount</returns>
        public double CalculateTaxableAmount(double income, double investment, double houseLoan)
        {
            Console.WriteLine(PrintResource.ValidInvestment + "\t:"+ ValidInvestment(investment) + Environment.NewLine + PrintResource.ExcludingAmount+"\t:" + FindExcluding(houseLoan, income));
            double taxableAmount = income - ValidInvestment(investment) - FindExcluding(houseLoan, income);
            return taxableAmount;
        }
        //This function return Valid Investment Value
        // Any amount invested (<=1 lakh) is non-taxable.
        public double CalculateTax(double taxableAmount, TaxSlabClassification taxSlab)
        {
            double tax = 0;
            if (_personalDetails.age >= 60)
            {
                tax = taxSlab.SeniorCitizen(taxableAmount);
            }
            else
            {
                if (_personalDetails.Gender == "M" || _personalDetails.Gender == "Male")
                {
                    tax = taxSlab.Male(taxableAmount);
                }
                else
                {
                    tax = taxSlab.Female(taxableAmount);
                }
            }
            //Math.Round(tax,0);
            return tax;
        }
        #region ValidInvestment Function
        /// <summary>
        /// This function return Valid Investment Value
        /// Any amount invested (<=1 lakh) is non-taxable
        /// </summary>
        /// <param name="investment"></param>
        /// <returns>Valid Investment Value that is non-taxable</returns>
        public double ValidInvestment(double investment)
        {
            if (investment - 100000 > 0)
                return 100000;
            else
                return investment;
            
        }
        #endregion
        #region FindExcluding Amount

        /// <summary>
        /// This function is used to find the Excluding Amount 
        /// <br></br>80% of the amount paid as Home Loan /House rent or 20% of Total Income whichever is less is non-taxable. 
        /// </summary>
        /// <param name="houseLoan"></param>
        /// <param name="income"></param>
        /// <returns></returns>
        public double FindExcluding(double houseLoan, double income)
        {
            double excludingAmount = 0;
            if (houseLoan * 0.8 < income * 0.2)
                excludingAmount = houseLoan * 0.8;
            else
                excludingAmount = income * 0.2;

            return excludingAmount;
        }
        #endregion
    }
}
