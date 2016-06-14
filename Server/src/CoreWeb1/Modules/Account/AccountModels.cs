namespace CoreWeb1.Modules.Account
{
    public class AccountModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AuthModel
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
