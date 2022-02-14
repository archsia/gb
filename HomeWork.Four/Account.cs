namespace HomeWork.Four
{
    public struct Account
    {
        private readonly string _password;
        private readonly string _login;

        public string Login => _login;

        public string Password => _password;

        public Account(string login, string password)
        {
            _login = login;
            _password = password;
        }

        public override string ToString()
        {
            return $"{_login} {_password}";
        }
    }
}