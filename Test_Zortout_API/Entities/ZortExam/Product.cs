using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Zortout_API.Entities.ZortExam
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
    }
}
