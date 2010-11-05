namespace SOLID.Examples.SingleResponsibilityPrinciple.RobsExerciseSolution
{
    internal class AuthenticationCommand
    {
        private readonly string _username;
        private readonly string _password;
        private readonly IUserRepository _userRepository;
        private User _user;

        public AuthenticationCommand(string username, string password,
                                     IUserRepository userRepository) {
            _username = username;
            _password = password;
            _userRepository = userRepository;
        }

        public bool DoLogin() {
            _user = _userRepository.GetUserByUsername(_username);

            if (UserIsValid()) {
                return true;
            }

            _userRepository.AddAFailedLoginAttemptFor(_user);

            return false;
        }

        private bool UserIsValid() {
            if (_user == null || MaxLoginAttemptsReached()) {
                return false;
            }

            return PasswordIsValid();
        }

        private bool MaxLoginAttemptsReached() {
            return (_userRepository.GetLockCountFor(_user) >= 3);
        }

        private bool PasswordIsValid() {
            return _password == _userRepository.GetPassword(_user.Username);
        }
    }
}