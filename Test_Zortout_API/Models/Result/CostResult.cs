using Newtonsoft.Json;

namespace Test_Zortout_API.Models.Result
{
    public class CostResult
    {
        public DateTime Timestamp { get; set; }
        public string OrderNumber { get; set; }
        public int? ProductCode { get; set; }
        public decimal? CostPerUnit { get; set; }
        public int? Quantity { get; set; }
        public string ProductName { get; set; }
    }
}