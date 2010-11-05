
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace SOLID.Examples.SingleResponsibilityPrinciple.Exercise
{
    [TestFixture]
    public class When_A_User_Attempts_To_Login
    {
        [Test]
        public void Should_Return_False_If_User_Not_Found_On_System()
        {
            Assert.That(new Authentication(new UserValidator()).Login("notexistinguser","password"), Is.False);
        }

        [Test]
        public void Should_Return_True_If_User_Found_And_Password_IsValid()
        {
            Assert.That(new Authentication(new UserValidator()).Login("username", "password"), Is.True);
        }

        [Test]
        public void Should_Return_False_If_User_Found_And_Password_Is_Not_Valid()
        {
            Assert.That(new Authentication(new UserValidator()).Login("username", "invalidpassword"), Is.False);
        }

        [Test]
        public void Should_Lock_User_If_Makes_Three_Invalid_Login_Attempts()
        {
            Authentication authentication = new Authentication(new UserValidator());
            authentication.Login("username", "invalidpassword");
            authentication.Login("username", "invalidpassword");
            authentication.Login("username", "invalidpassword");

            Assert.That(authentication.Login("username", "password"), Is.False);

        }

        [TearDown]
        public void TearDown()
        {
            new User().SetLockCount(0);
        }
    }
}
