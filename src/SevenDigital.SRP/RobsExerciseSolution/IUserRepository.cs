namespace SOLID.Examples.SingleResponsibilityPrinciple.RobsExerciseSolution
{
    internal interface IUserRepository
    {
        User GetUserByUsername(string username);
        string GetPassword(string username);
        int GetLockCountFor(User user);
        void AddAFailedLoginAttemptFor(User user);
    }
}