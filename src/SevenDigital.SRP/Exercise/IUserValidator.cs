namespace SOLID.Examples.SingleResponsibilityPrinciple.Exercise
{
    public interface IUserValidator {
        bool ValidateUser(User user, string password);
    }
}