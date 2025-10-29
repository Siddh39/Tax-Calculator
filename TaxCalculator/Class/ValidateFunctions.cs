using System.Text.RegularExpressions;
using TaxCalculator.Constant;
using TaxCalculator.Enum;
using TaxCalculator.Resource;




namespace TaxCalculator.Class
{

    public class ValidateFunctions
    {
        /// <summary>
        /// This function checks wether the Name is Entered Correct or Not
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="Exception"></exception>
        public static void ValidateName(string name)
        {

            if (Regex.IsMatch(name, Patterns.NamePattern1))
            {
                throw new ArgumentException(ErrorMessages.NameValidation);
            }
            if (!Regex.Match(name, Patterns.NamePattern2).Success)
            {
                throw new Exception(ErrorMessages.Name);
            }
            if (!Regex.Match(name, Patterns.NamePattern3).Success)
            {
                throw new Exception(ErrorMessages.EmptyName);
            }
        }
        /// <summary>
        /// This functions checks wether th Birthdate is entered Correctly or not
        /// </summary>
        /// <param name="date"></param>
        /// <exception cref="Exception"></exception>
        public static void ValidateBirthdate(DateTime date)
        {
            DateTime parsedDate;
            DateTime today = DateTime.Today;
            string onlyDate = date.Date.ToShortDateString();
            if (!DateTime.TryParseExact(onlyDate, ErrorMessages.DateFormat, null, System.Globalization.DateTimeStyles.None, out parsedDate))
            {
                throw new Exception(Environment.NewLine + ErrorMessages.Date + ErrorMessages.DateFormat);
            }
            if (date > today)
            {
                throw new Exception(ErrorMessages.dayGreater);
            }

        }
        /// <summary>
        /// This function check the Gender is entered properly or not
        /// </summary>
        /// <param name="gender"></param>
        /// <exception cref="Exception"></exception>
        public static void ValidateGender(string gender)
        {

            if (Male.IsDefined(typeof(Male), gender))
            {
                gender = PrintResource.Male;
            }
            else if (Female.IsDefined(typeof(Female), gender))
            {
                gender = PrintResource.Female;
            }
            else
                throw new Exception( ErrorMessages.Gender);
        }
        /// <summary>
        /// This functions checks wether the Number is not null or negative,
        /// <br></br>if the number is greater than limit it throws exception
        /// </summary>
        /// <param name="number"></param>
        /// <exception cref="Exception"></exception>
        public static void ValidateNumber(double number)
        {
            if (double.IsNaN(number)) { throw new Exception(Environment.NewLine + ErrorMessages.EnterNumber); }
            if (number < 0) { throw new Exception(Environment.NewLine + ErrorMessages.PositiveInteger); }
            if (number > 1000000000000000d)
            {
                throw new Exception(ErrorMessages.GreaterThanLimit);
            }
        }
        /// <summary>
        /// This functions Validates the Income, if Income is zero or negative it throws error, if Income is greater than limit it throws Error
        /// </summary>
        /// <param name="income"></param>
        /// <exception cref="Exception"></exception>
        public static void ValidateIncome(double income)
        {
            
            if (double.IsNaN(income)) { throw new Exception(ErrorMessages.IncomeNullEntry); }
            if (income < 0) { throw new Exception(ErrorMessages.PositiveInteger); }
            if (income == 0) { throw new Exception(ErrorMessages.ShouldNotBeZero); }
            if (income > 1000000000000000d)
            {
                throw new Exception(ErrorMessages.GreaterThanLimit);
            }
        }
        /// <summary>
        /// This functions checks wether Sum of Investment and House Loan is not Greater than Income
        /// </summary>
        /// <param name="income"></param>
        /// <param name="investment"></param>
        /// <param name="houseLoan"></param>
        /// <exception cref="Exception">If income is less than sum than throw error</exception>
        public static void CheckAccount(double income, double investment, double houseLoan)
        {
            if (investment + houseLoan > income)
            {
                throw new Exception(ErrorMessages.GreaterThanIncome);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ans"></param>
        /// <exception cref="Exception"></exception>
        public static void ValidateAns(string ans)
        {
            if (string.IsNullOrEmpty(ans))
            {
                throw new Exception(PrintResource.YorN);
            }
            else if (!(YesNo.IsDefined(typeof(YesNo), ans)))

            {
                throw new Exception(ErrorMessages.EnterYorN);

            }

        }
    }
}