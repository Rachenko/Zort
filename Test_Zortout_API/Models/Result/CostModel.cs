using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Test_Zortout_API.Models.Result
{
    public class CostModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("data")]
        public List<CostData> Data { get; set; } = new List<CostData>();
        [JsonProperty("error")]
        public CostError Error { get; set; }
    }

    public class CostData
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; }
        [JsonProperty("productCode")]
        public int? ProductCode { get; set; }
        [JsonProperty("costPerUnit")]
        public decimal? CostPerUnit { get; set; }
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }
    }

    public class CostError
    {
        [JsonProperty("code")]
        public int? Code { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
