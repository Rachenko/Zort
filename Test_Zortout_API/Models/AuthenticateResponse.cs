using Test_Zortout_API.Models.Result;

namespace Test_Zortout_API.Models
{
    public class AuthenticateResponse : BaseResponse<AuthenticateResult>
    {
        public AuthenticateResponse(AuthenticateResult result) : base(result)
        { }

        public AuthenticateResponse(string errorMessage) : base(errorMessage)
        { }
    }
}
