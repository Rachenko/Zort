using Newtonsoft.Json;
namespace Test_Zortout_API.Models.Result
{
    public class AuthenticateModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("data")]
        public AuthenticateData Data { get; set; }
        [JsonProperty("error")]
        public AuthenticateError Error { get; set; }
    }

    public class AuthenticateData
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty("expiry")]
        public DateTime Expiry { get; set; }
    }

    public class AuthenticateError
    {
        [JsonProperty("code")]
        public int? Code { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
