using Test_Zortout_API.Models.Result;

namespace Test_Zortout_API.Models
{
    public class CostResponse : BaseResponse<List<CostResult>>
    {
        public CostResponse(List<CostResult> result) : base(result)
        { }

        public CostResponse(string errorMessage) : base(errorMessage)
        { }
    }
}
