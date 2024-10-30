using Test_Zortout_API.Models.Result;

namespace Test_Zortout_API.Models
{
    public class TotalSalesResponse : BaseResponse<List<TotalSalesResult>>
    {
        public TotalSalesResponse(List<TotalSalesResult> result) : base(result)
        { }

        public TotalSalesResponse(string errorMessage) : base(errorMessage)
        { }
    }
}
