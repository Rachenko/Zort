namespace Test_Zortout_API.Models.Result
{
    public class AuthenticateResult
    {
        public string Type { get; set; }
        public string AccessToken { get; set; }
        public DateTime Expiry { get; set; }
    }
}
