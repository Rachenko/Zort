using Test_Zortout_API.Models.Request;
using Test_Zortout_API.Models.Result;

namespace Test_Zortout_API.External.Interface
{
    public interface IZortApi
    {
        Task<AuthenticateModel> Authenticate(AuthenticateRequest request);
        Task<CostModel> Cost(string from, string to, string token);
        public Task<string> GetTest();
    }
}
