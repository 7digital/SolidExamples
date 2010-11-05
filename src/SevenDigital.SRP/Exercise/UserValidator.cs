namespace SOLID.Examples.SingleResponsibilityPrinciple.Exercise
{
    public class UserValidator : IUserValidator
    {
        public bool ValidateUser(User user, string password)
        {
            if (user == null)
                return false;

            if (user.FailedLoginAttempts >= 3)
                return false;

            return (password == user.GetPassword(user.Username));
        }
    }
}