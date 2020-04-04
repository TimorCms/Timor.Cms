namespace Timor.Cms.Api.ViewModels.Account
{
    public class LoginResult
    {
        public string TokenType { get; set; }

        public string Token { get; set; }

        public double ExpireInSeconds { get; set; }

        public string UserName { get; set; }

    }
}
