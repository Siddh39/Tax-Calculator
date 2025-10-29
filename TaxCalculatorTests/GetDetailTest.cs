using TaxCalculator.Class;

namespace MyTest1
{
    [TestClass]
    public sealed class GetDetailTest
    {
        [TestMethod]
        public void PersonalInfo_Name_ContainsNumber()
        {
            try
            {
                // Arrange
                GetDetail pd = new GetDetail();
                // Act
                pd.Name = "umang12";
                // Assert
                Assert.Fail("Exception Failed, Required Exception is not thrown");
            }
            catch (ArgumentException ex)
            {
                string expected = "Please Enter only Alphabets in Name, Name cannot contain Digits";

                // Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod] 
        public void PersonalInfo_Name_isCorrect()
        {
            GetDetail pd=new GetDetail();
            string ans = "Umang";
            //act
            pd.Name = "Umang";
            //assert
            Assert.AreEqual(ans,pd.Name);    
        }

        [TestMethod]
        public void PersonalInfo_Name_IsNull()
        {
            try
            {
                // Arrange
                GetDetail pd = new GetDetail();
                // Act
                pd.Name = "";
                // Assert
                Assert.Fail("Exception Failed, Required Exception is not thrown");
            }
            catch (Exception ex)
            {
                string expected = "Name Should not Start with Empty Space and Atleast one character should be there ";
                // Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void PersonalInfo_Name_SpecialCharacters()
        {
            try
            {
                // Arrange
                GetDetail pd = new GetDetail();

                // Act
                pd.Name = "umang@patel";

                // Assert
                Assert.Fail("Exception Failed, Required Exception is not thrown");
            }
            catch (Exception ex)
            {
                string expected = "Please Enter Name Properly";

                // Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void PersonalInfo_BirthDate_SpecialCharacters()
        {
            try
            {
                // Arrange
                GetDetail pd = new GetDetail();

                // Act
                pd.Birthdate = DateTime.Parse("31/04/2004");

                // Assert
                Assert.Fail("Exception Failed, Required Exception is not thrown");
            }
            catch (Exception ex)
            {
                string expected = "String '31/04/2004' was not recognized as a valid DateTime.";

                // Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void PersonalInfo_BirthDate_Future()
        {
            try
            {
                // Arrange
                GetDetail pd = new GetDetail();

                // Act
                pd.Birthdate = DateTime.Parse("22/04/2501");

                // Assert
                Assert.Fail("Exception Failed, Required Exception is not thrown");
            }
            catch (Exception ex)
            {
                string expected = "Entered Birth Date is Greater than Todays Date";

                // Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void PersonalInfo_BirthDate_WrongFormat()
        {
            try
            {
                // Arrange
                GetDetail pd = new GetDetail();

                // Act
                pd.Birthdate = DateTime.Parse("22042501");

                // Assert
                Assert.Fail("Exception Failed, Required Exception is not thrown");
            }
            catch (Exception ex)
            {
                string expected = "String '22042501' was not recognized as a valid DateTime.";

                // Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void CalculateAge_Age_GreaterThan100()
        {
            try
            {
                // Arrange
                GetDetail pd = new GetDetail();

                // Act
                pd.Birthdate = DateTime.Parse("22/04/1915");
                GetDetail.CalculateAge(pd.Birthdate);

                // Assert
                Assert.Fail("Exception Failed, Required Exception is not Thrown");
            }
            catch (Exception ex)
            {
                string expected = "Age Cannot be Greater than 100";

                // Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void CalculateAge_Age_LessThan100()
        {
            try
            {
                // Arrange
                GetDetail pd = new GetDetail();

                // Act
                pd.Birthdate = DateTime.Parse("22/04/2015");
                GetDetail.CalculateAge(pd.Birthdate);

                // Assert
                Assert.Fail("Exception Failed, Required Exception is not Thrown");
            }
            catch (Exception ex)
            {
                string expected = "Age Should be greater than 18";

                // Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void PersonalInfo_Gender_IsNotMaleNotFemale()
        {
            try
            {
                // Arrange
                GetDetail pd = new GetDetail();

                // Act
                pd.Gender = "qwev";

                // Assert
                Assert.Fail("Exception Failed, Required Exception is not thrown");
            }
            catch (Exception ex)
            {
                string expected = "Gender should be Male or Female";

                // Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        public void PersonalInfo_Gender_IsMale()
        {
            
                // Arrange
                GetDetail pd = new GetDetail();
                string expected = "Male";
                // Act
                pd.Gender = "M";

                // Assert
                Assert.AreEqual(expected, pd.Gender);
            
            
        }
        [TestMethod]
        public void AccountDetail_Income_IsNegative()
        {
            try
            {
                // Arrange
                GetDetail ad = new GetDetail();

                // Act
                ad.Income = -52;

                // Assert
                Assert.Fail("Exception Failed, Required Exception is not thrown");
            }
            catch (Exception ex)
            {
                string expected = "Enter a positive number";

                // Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void AccountDetail_Income_IsZero()
        {
            try
            {
                // Arrange
                GetDetail ad = new GetDetail();

                // Act
                ad.Income = 0;

                // Assert
                Assert.Fail("Exception Failed, Required Exception is not thrown");
            }
            catch (Exception ex)
            {
                string expected = "The Income Value should Not be Zero";

                // Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void AccountDetail_InvestmentHouseLoan_SumGreaterThanIncome()
        {
            try
            {
                // Arrange
                GetDetail ad = new GetDetail();

                // Act
                ad.Income = 25;
                ad.Investment = 20;
                ad.HouseLoan = 10;
                ValidateFunctions.CheckAccount(ad.Income, ad.Investment, ad.HouseLoan);

                // Assert
                Assert.Fail("Exception Failed, Required Exception is not thrown");
            }
            catch (Exception ex)
            {
                string expected = "Your investment and Loan should not be greater than Income!!!!!!!!";

                // Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}
