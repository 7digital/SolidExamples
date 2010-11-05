using System;
using System.IO;
using System.Text;

namespace SOLID.Examples.SingleResponsibilityPrinciple.RobsExerciseSolution
{
    //This class is a bit messy, but it's really only a fake for the sake of testing
    internal class FakeUserRepository : IUserRepository
    {
        private const string PATH = @"C:\Projects\Dojos\SOLIDPrinciplesExamples\SOLIDPrinciplesExamples\SingleResponsibilityPrinciple\RobsExerciseSolution\UserDb.txt";
        private const string EXPECTED_USERNAME = "username";
        private const string PASSWORD = "password";

        public User GetUserByUsername(string username)
        {
            if (username == EXPECTED_USERNAME)
            {
                return new User {Password = PASSWORD, Username = EXPECTED_USERNAME};
            }

            return null;
        }

        public string GetPassword(string username)
        {
            if (username == EXPECTED_USERNAME)
                return PASSWORD;

            return string.Empty;
        }

        public int GetLockCountFor(User user)
        {
            //there would obviously be some logic here to get the user but ommited for the sake of brevity

            using (StreamReader re = File.OpenText(PATH))
            {
                string input = null;
                while ((input = re.ReadLine()) != null)
                {
                    return Convert.ToInt32(input);
                }
            }

            throw new Exception("Didn't work");
        }

        internal void SetLockCountFor(User user, int lockCount)
        {
            //there would obviously be some logic here to get the user but ommited for the sake of brevity

            using (FileStream fs = File.OpenWrite(PATH))
            {
                Byte[] byteLockCount = new UTF8Encoding(true).GetBytes(lockCount.ToString());
                fs.Write(byteLockCount, 0, byteLockCount.Length);
            }
        }

        public void AddAFailedLoginAttemptFor(User user)
        {
            SetLockCountFor(user, GetLockCountFor(user) + 1);
        }

    }
}