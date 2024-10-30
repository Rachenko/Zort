using Test_Zortout_API.Entities.ZortExam;
using Test_Zortout_API.Models.Result;

namespace Test_Zortout_API.Repositories.Interface
{
    public interface ITestRepositories
    {
        public Task<List<Product>> GetProduct();
        public Task<List<TotalSalesResult>> GetTotalSales(DateTime fromDate, DateTime toDate, int[] ProductCode);
    }
}
