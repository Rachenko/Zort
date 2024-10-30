using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Zortout_API.Entities.ZortExam
{
    [Table("OrderProduct")]
    public class OrderProduct
    {
        public string OrderNumber { get; set; }
        public int ProductCode { get; set; }
        public decimal? PricePerUnit { get; set; }
        public int Quantity { get; set; }
    }
}
