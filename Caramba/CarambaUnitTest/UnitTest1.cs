using NUnit.Framework;

namespace CarambaUnitTest
{
    public class Tests
    {
        [Test]
        public void RegisterUser()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;

            // Act


            // Assert
            Assert.AreEqual(expected, 0.001, "Account not debited correctly");
        }
    }
}