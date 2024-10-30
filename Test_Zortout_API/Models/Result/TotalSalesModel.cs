using Newtonsoft.Json;

namespace Test_Zortout_API.Models.Result
{
    public class TotalSalesModel
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal? TotalSales { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}