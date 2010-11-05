using System;
using System.IO;
using System.Text;

namespace SOLID.Examples.SingleResponsibilityPrinciple.Exercise
{
    internal class Authentication
    {
        private readonly IUserValidator _userValidator;

        public Authentication(IUserValidator userValidator) {
            _userValidator = userValidator;
        }

        public bool Login(string username, string password)
        {
            var user = new User().GetUserByUsername(username);
            bool isValid = _userValidator.ValidateUser(user, password);

            if (!isValid && user != null) {
                user.AddFailedLoginAttempt();
            }

            return isValid;
        }
    }

    public class User
    {
        private const string path = @"C:\Projects\Dojos\SOLIDPrinciplesExamples\SOLIDPrinciplesExamples\SingleResponsibilityPrinciple\Exercise\UserDb.txt";
        
        public string Password { get; set; }
        public string Username { get; set; }
        public bool LockedOut { get; set; }

        public int FailedLoginAttempts
        {
            get { return GetLockCount(); }
        }

        internal int GetLockCount()
        {
           
           using(StreamReader re = File.OpenText(path))
           {
               string input = null;
               while ((input = re.ReadLine()) != null)
               {
                   return Convert.ToInt32(input);
               }
           }
          

            throw new Exception("Didn't work");
        }

        internal void SetLockCount(int lockCount)
        {
            using (FileStream fs = File.OpenWrite(path))
            {
                Byte[] byteLockCount = new UTF8Encoding(true).GetBytes(lockCount.ToString());
                fs.Write(byteLockCount,0,byteLockCount.Length);
            }
        }

        public void AddFailedLoginAttempt()
        {
            SetLockCount(GetLockCount()+1);
        }

        private const string expectedUsername = "username";
        private const string password = "password";

        public User GetUserByUsername(string username)
        {
            if (username == expectedUsername)
            {
                return new User() { Password = password, Username = expectedUsername };
            }

            return null;
        }

        public string GetPassword(string username)
        {
            if (username == expectedUsername)
                return password;

            return string.Empty;
        }
    }
}