
using System.Diagnostics;
using TaxCalculator.Class;
using TaxCalculator.Resource;

namespace TaxCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                GetDetail allInputs = new GetDetail();
                TaxCalculation taxCalculation = new TaxCalculation(allInputs);
                TaxSlabClassification taxSlab = new TaxSlabClassification();
                PrintDetail printDetails = new PrintDetail(allInputs, taxCalculation, taxSlab);
                allInputs.EnterPersonalDetails();
                printDetails.PrintPersonal();
                allInputs.EnterAccountDetails();
                printDetails.PrintAccount();
                printDetails.PrintTax();
                double result = printDetails.Tax;

                string ans;
                while (true)
                {
                    try
                    {
                        Console.Write(Environment.NewLine + PrintResource.WantToContinue);
                        ans = Console.ReadLine()!;
                        ValidateFunctions.ValidateAns(ans);
                        break;
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                }
                if (ans == "N" || ans == "n")
                {
                    break;
                }
                Console.Clear();
            }
        }
    }
}
