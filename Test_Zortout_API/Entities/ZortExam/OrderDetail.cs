using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Zortout_API.Entities.ZortExam
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        public string OrderNumber { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
