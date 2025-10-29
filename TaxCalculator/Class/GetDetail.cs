using TaxCalculator.Enum;
using TaxCalculator.Resource;

namespace TaxCalculator.Class
{
    /// <summary>
    /// This Class Implements the Interface 
    /// </summary>
    public class GetDetail : IAllDetails
    {
        #region Variables and Properties
        
        private string? _name;
        private DateTime _birthdate;
        private string? _gender;
        public int age;
        double _income;
        double _investment;
        double _houseLoan;
        public string Name
        {
            get => _name!;
            set
            {
                _name = value;
                ValidateFunctions.ValidateName(_name);
            }
        }
        public DateTime Birthdate
        {
            get { return _birthdate!; }
            set
            {
                ValidateFunctions.ValidateBirthdate(value);
                _birthdate = value;

                
            }
        }
        public string Gender
        {
            get => _gender!;
            set
            {
                _gender = value;
                ValidateFunctions.ValidateGender(_gender);
                if (Male.IsDefined(typeof(Male), _gender))
                {
                    _gender = PrintResource.Male;
                }
                else if (Female.IsDefined(typeof(Female), _gender)) 
                {
                    _gender = PrintResource.Female;
                }
            }
        }
        public double Income
        {
            get { return _income; }
            set
            {
                _income = value;
                ValidateFunctions.ValidateIncome(value);
            }
        }
        public double Investment
        {
            get { return _investment; }
            set
            {
                _investment = value;
                ValidateFunctions.ValidateNumber(value);
            }
        }
        public double HouseLoan
        {
            get { return _houseLoan; }
            set
            {
                _houseLoan = value;
                ValidateFunctions.ValidateNumber(value);
            }
        }
        #endregion


        public void EnterPersonalDetails()
        {
            PersonalInfo();

        }
        public void EnterAccountDetails()
        {
            AccountInfo();

        }
        #region Input Function for Personal Details
        /// <summary>
        /// This function takes the Input from The User for Person Details
        /// </summary>
        public void PersonalInfo()
        {
            while (true)
            {
                try
                {
                    Console.Write(Environment.NewLine + PrintResource.Name + ":");
                    Name = Console.ReadLine()!;
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(ErrorMessages.Exclamation);
                }
            }
            while (true)
            {
                try
                {
                    Console.Write(Environment.NewLine + PrintResource.DateWithFormat + ":");
                    Birthdate = DateTime.Parse(Console.ReadLine()!);
                    age = CalculateAge(Birthdate);
                    Console.WriteLine("Age:" + age);
                    break;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Console.WriteLine(ErrorMessages.Exclamation);
                }
            }
            while (true)
            {
                try
                {
                    Console.Write(Environment.NewLine + PrintResource.Gender + ":");
                    Gender = Console.ReadLine()!;
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(Environment.NewLine + e.Message);
                    Console.WriteLine(ErrorMessages.Exclamation);
                }
            }
        }
        #endregion

        #region Input Function for Account Details
        public void AccountInfo()
        {
            Console.WriteLine(Environment.NewLine + Environment.NewLine + PrintResource.AccountDetails);

            Console.WriteLine(Environment.NewLine + PrintResource.EnterDetails);
            while (true)
            {
                try
                {
                    Console.Write(Environment.NewLine + PrintResource.Income + ":");
                    Income = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (FormatException) { Console.WriteLine(ErrorMessages.EnterNumber); }
                catch (Exception e) { Console.WriteLine(Environment.NewLine + e.Message); }
            }
            while (true)
            {
                try
                {
                    Console.Write(Environment.NewLine + PrintResource.Investment+":");
                    Investment = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (FormatException) { Console.WriteLine(ErrorMessages.EnterNumber); }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }

            while (true)
            {
                try
                {
                    Console.Write(Environment.NewLine + PrintResource.HouseLoan + ":");
                    HouseLoan = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (FormatException) { Console.WriteLine(ErrorMessages.EnterNumber); }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
            while (true)
            {
                try
                {
                    ValidateFunctions.CheckAccount(Income, Investment, HouseLoan);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    AccountInfo();
                }
            }

        }
        #endregion


        /// <summary>
        /// This functions Calculate the Age from the Date entered by User
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Age of User</returns>
        public static int CalculateAge(DateTime date)

        {
            DateTime now = DateTime.Today;
            int day = date.Day;
            int birthMonth = date.Month;
            int birthYear = date.Year;
            int age = now.Year - birthYear;
            if (age > 100)
            {
                throw new Exception(ErrorMessages.AgeLessThan100);
            }
            if (age < 18)
            {
                throw new Exception(ErrorMessages.AgeGreaterThan18);
            }
            if (now.Month < birthMonth)
            {
                age--;
            }
            else if (now.Day < day)
            {
                age--;
            }
            return age;
        }
    }
}
