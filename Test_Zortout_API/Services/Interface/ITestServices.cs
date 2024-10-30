using System.Threading.Tasks;
using Test_Zortout_API.Models.Request;
using Test_Zortout_API.Models.Result;

namespace Test_Zortout_API.Services.Interface
{
    public interface ITestServices
    {
        public Task<AuthenticateResult> GetAuthenticate(AuthenticateRequest request);
        public Task<List<CostResult>> GetCost(CostRequest request, string token);
        public Task<List<TotalSalesResult>> GetTotalSales(TotalSalesRequest request);
    }
}
