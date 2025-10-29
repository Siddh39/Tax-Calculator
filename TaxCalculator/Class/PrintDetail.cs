
using TaxCalculator.Resource;

namespace TaxCalculator.Class
{
    public class PrintDetail
    {
        #region Declaration and Constructor
        GetDetail _allInputs;
        TaxSlabClassification _taxSlab;
        TaxCalculation _taxCalculation;
        double _tax;
        public double Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }
        public PrintDetail( GetDetail allInputs, TaxCalculation taxCalculation, TaxSlabClassification taxSlab)
        {
            _allInputs = allInputs;
            _taxCalculation = taxCalculation;
            _taxSlab = taxSlab;
        }
        #endregion
        public void PrintPersonal()
        {
            Console.Clear();
            string design= new string('=', Console.WindowWidth);
            string design2 = new string('-', Console.WindowWidth);
            Console.WriteLine(design2);
            string mainHeading = PrintResource.MainHeading;
            Console.SetCursorPosition((Console.WindowWidth - mainHeading.Length) / 2, Console.CursorTop);
            Console.WriteLine(mainHeading);
            Console.WriteLine(design2);

            Console.WriteLine(design);
            string Heading1 = PrintResource.PersonalDetail;
            Console.SetCursorPosition((Console.WindowWidth - Heading1.Length) / 2, Console.CursorTop);
            Console.WriteLine(Heading1);
            Console.WriteLine(design);
            Console.WriteLine(PrintResource.Name+"\t\t\t:" + _allInputs.Name);
            Console.WriteLine(PrintResource.Birthdate+"\t\t:" + _allInputs.Birthdate);
            Console.WriteLine(PrintResource.Age+"\t\t\t:" + _allInputs.age);
            Console.WriteLine(PrintResource.Gender+"\t\t\t:" + _allInputs.Gender);
            
        }
        public void PrintAccount()
        {
            Console.Clear();
            PrintPersonal();
            string design = new string('=', Console.WindowWidth);
            Console.WriteLine(design);
            string Heading2 = PrintResource.AccountDetails;
            Console.SetCursorPosition((Console.WindowWidth - Heading2.Length) / 2, Console.CursorTop);
            Console.WriteLine(Heading2);
            Console.WriteLine(design);
            Console.WriteLine(PrintResource.Income + "\t\t\t:" + _allInputs.Income);
            Console.WriteLine(PrintResource.Investment + "\t\t:" + _allInputs.Investment);
            Console.WriteLine(PrintResource.HouseLoan + "\t:" + _allInputs.HouseLoan);
            
        }
        public void PrintTax()
        {
            string design = new string('=', Console.WindowWidth);
            Console.WriteLine(design);
            string Heading3 = PrintResource.TaxCalculation;
            Console.SetCursorPosition((Console.WindowWidth - Heading3.Length) / 2, Console.CursorTop);
            Console.WriteLine(Heading3);
            Console.WriteLine(design);
            double taxableAmount = _taxCalculation.CalculateTaxableAmount(_allInputs.Income, _allInputs.Investment, _allInputs.HouseLoan);
            Console.WriteLine(PrintResource.TaxableAmount + "\t\t:" + taxableAmount);
            Tax= _taxCalculation.CalculateTax(taxableAmount, _taxSlab);
            Console.WriteLine(PrintResource.Tax + "\t\t\t:" + Tax);
        }
    }
}
