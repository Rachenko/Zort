using System.ComponentModel.DataAnnotations;

namespace Test_Zortout_API.Models.Request
{
    public class TotalSalesRequest
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int[] ProductCode { get; set; }
    }
}
