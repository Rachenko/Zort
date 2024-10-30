using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using Test_Zortout_API.External.Interface;
using Test_Zortout_API.Helper.Interface;
using Test_Zortout_API.Models.Request;
using Test_Zortout_API.Models.Result;

namespace Test_Zortout_API.External
{
    public class ZortApi : IZortApi
    {
        private readonly IAppSettingHelper _appsettingHelper;
        private readonly IHttpClientFactory _clientFactory;
        private string _baseUrl;

        public ZortApi
        (
            IHttpClientFactory clientFactory,
            IAppSettingHelper appsettingHelper
        )
        {
            _clientFactory = clientFactory;
            _appsettingHelper = appsettingHelper;
            _baseUrl = _appsettingHelper.GetValue("ZortApi:BaseUrl");
        }
        public async Task<AuthenticateModel> Authenticate(AuthenticateRequest request)
        {
            string url = _baseUrl + _appsettingHelper.GetValue("ZortApi:Authenticate");
            string bodyRequest = JsonConvert.SerializeObject(request);
            HttpClient client = _clientFactory.CreateClient();
            var content = new StringContent(bodyRequest, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);
            var str = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AuthenticateModel>(str);
        }

        public async Task<CostModel> Cost(string from, string to, string token)
        {
            string url = _baseUrl + _appsettingHelper.GetValue("ZortApi:Cost");
            url = url.Replace("{From}", from);
            url = url.Replace("{To}", to);

            HttpClient client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(url);
            var str = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CostModel>(str);
        }

        public async Task<string> GetTest()
        {
            return "";
        }
    }
}
