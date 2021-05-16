using NUnit.Framework;
using TornamentManager.AutorizationLogic;


namespace TournamentManager.Tests
{
    public class AutorizationTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase("Admin")]
        [TestCase("User")]
        [TestCase("sergey")]
        [TestCase("A")]
        public void ValidateLogin_test_WhenTrue(string login)
        {
            IAutorization autorization = new Autorization();
            bool actual = autorization.validateLogin(login);
            bool expected = true;
            Assert.AreEqual(actual, expected);
        }

        [TestCase("")]
        [TestCase("!!!")]
        [TestCase("1_g")]
        [TestCase("d d")]
        [TestCase("gfff ")]
        public void ValidateLogin_test_WhenFalse(string login)
        {
            IAutorization autorization = new Autorization();
            bool actual = autorization.validateLogin(login);
            bool expected = false;
            Assert.AreEqual(actual, expected);
        }

        [TestCase("Admin")]
        [TestCase("User")]
        [TestCase("sergey")]
        [TestCase("Avahhh")]
        public void ValidatePassword_test_Valid(string login)
        {
            IAutorization autorization = new Autorization();
            bool actual = autorization.validateLogin(login);
            bool expected = true;
            Assert.AreEqual(actual, expected);
        }

        [TestCase("")]
        [TestCase("A")]
        [TestCase("1")]
        [TestCase("d d")]
        [TestCase("gfff ")]
        public void ValidatePassword_test_Invalid(string login)
        {
            IAutorization autorization = new Autorization();
            bool actual = autorization.validateLogin(login);
            bool expected = false;
            Assert.AreEqual(actual, expected);
        }
        [TestCase("Admin", "Admin", EUserPrivileges.Admin)]
        [TestCase("Root", "Admin", EUserPrivileges.Admin)]
        [TestCase("User", "root", EUserPrivileges.Admin)]
        public void CreateUser_WhenLoginPasswordUserPrivilages_ShouldTrue(string login, string password, EUserPrivileges userPrivilages)
        {
            IAutorization autorization = new Autorization();
            IUser actual = autorization.CreateUser(login, password, userPrivilages);
            
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Login, login);
            Assert.AreEqual(actual.Password, password);
            Assert.AreEqual(actual.UserPrivilages, userPrivilages);
        }

        [TestCase("A dmin", "Admin", EUserPrivileges.Admin)]
        public void CreateUser_WhenLoginPasswordUserPrivilages_ShouldFalse(string login, string password, EUserPrivileges userPrivilages)
        {
            IAutorization autorization = new Autorization();
            IUser actual = autorization.CreateUser(login, password, userPrivilages);

            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Login, login);
            Assert.AreEqual(actual.Password, password);
            Assert.AreEqual(actual.UserPrivilages, userPrivilages);
        }
    }
}