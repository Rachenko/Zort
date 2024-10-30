using Newtonsoft.Json;

namespace Test_Zortout_API.Models.Result
{
    public class TotalSalesResult
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal? TotalSales { get; set; }
    }
}