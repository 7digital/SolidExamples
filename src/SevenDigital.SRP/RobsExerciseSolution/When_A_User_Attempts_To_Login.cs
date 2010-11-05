
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;


namespace SOLID.Examples.SingleResponsibilityPrinciple.RobsExerciseSolution
{
    [TestFixture]
    public class When_A_User_Attempts_To_Login2
    {
        [Test]
        public void Should_Return_False_If_User_Not_Found_On_System()
        {
            Assert.That(new AuthenticationCommand("notexistinguser", "password", new FakeUserRepository()).DoLogin(), Is.False);
        }

        [Test]
        public void Should_Return_True_If_User_Found_And_Password_IsValid()
        {
            Assert.That(new AuthenticationCommand("username", "password", new FakeUserRepository()).DoLogin(), Is.True);
        }

        [Test]
        public void Should_Return_False_If_User_Found_And_Password_Is_Not_Valid()
        {
            Assert.That(new AuthenticationCommand("username", "invalidpassword",  new FakeUserRepository()).DoLogin(), Is.False);
        }

        [Test]
        public void Should_Lock_User_If_Makes_Three_Invalid_Login_Attempts()
        {
            new AuthenticationCommand("username", "invalidpassword", new FakeUserRepository()).DoLogin();
            new AuthenticationCommand("username", "invalidpassword", new FakeUserRepository()).DoLogin();
            new AuthenticationCommand("username", "invalidpassword",  new FakeUserRepository()).DoLogin();

            Assert.That(new AuthenticationCommand("username", "password",  new FakeUserRepository()).DoLogin(), Is.False);

        }

        [TearDown]
        public void TearDown()
        {
            new FakeUserRepository().SetLockCountFor(null, 0);
        }
    }
}
