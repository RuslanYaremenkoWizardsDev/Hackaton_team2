using NUnit.Framework;
using System.IO;
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
        public void ValidateLogin_WhenLogin_ShouldTrue(string login)
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
        public void ValidateLogin_WhenLogin_ShouldFalse(string login)
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
        public void ValidatePassword_WhenPassword_ShouldValid(string password)
        {
            IAutorization autorization = new Autorization();
            bool actual = autorization.validatePassword(password);
            bool expected = true;

            Assert.AreEqual(actual, expected);
        }

        [TestCase("")]
        [TestCase("A")]
        [TestCase("1")]
        [TestCase("d d")]
        [TestCase("gfff ")]
        public void ValidatePassword_WhenPassword_ShouldInvalid(string password)
        {
            IAutorization autorization = new Autorization();
            bool actual = autorization.validatePassword(password);
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

        [TestCase("mi", "", EUserPrivileges.Admin)]
        [TestCase("1", "11", EUserPrivileges.Admin)]
        [TestCase("@@", "11", EUserPrivileges.Admin)]
        public void CreateUser_WhenLoginPasswordInvalid_ShouldFalse(string login, string password, EUserPrivileges userPrivilages)
        {
            IAutorization autorization = new Autorization();
            IUser actual = autorization.CreateUser(login, password, userPrivilages);

            Assert.IsNull(actual);
        }

        [TestCase("Admin", "Admin", EUserPrivileges.Admin)]
        public void CreateUser_WhenDuplicateLogin_ShouldFalse(string login, string password, EUserPrivileges userPrivilages)
        {
            IAutorization autorization = new Autorization();
            IUser actual = autorization.CreateUser(login, password, userPrivilages);
            
            Assert.IsNotNull(actual);
            actual = autorization.CreateUser(login, password, userPrivilages);
            Assert.Null(actual);
        }
        [Test]
        public void SaveUsers_OneUser()
        {
            IAutorization autorization = new Autorization();
            IUser actual = autorization.CreateUser("Admin", "AdminPwd", EUserPrivileges.Admin);
            autorization.SaveUsers(new StreamWriter("C:/temp.txt"));

            string tmpString = new StreamReader("C:/temp.txt").ReadToEnd().Trim();
            string expected = "1" + "\r\n"+"Admin"+"\r\n"+"AdminPwd"+"\r\n"+"1";
            expected = expected.Trim();
            Assert.AreEqual(expected, tmpString);
            new FileInfo("C:/temp.txt").Delete();
        }
    }
}