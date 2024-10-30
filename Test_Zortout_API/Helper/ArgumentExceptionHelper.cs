using Newtonsoft.Json;
using Test_Zortout_API.Models;

namespace Test_Zortout_API.Helper
{
    public static class ArgumentExceptionHelper
    {
        public static void Throw(int code, string message)
        {
            List<ErrorInnerResource> errResource = new List<ErrorInnerResource>();
            errResource.Add(new ErrorInnerResource { Code = code, Message = message });
            string json = JsonConvert.SerializeObject(errResource);
            throw new ArgumentException(json);
        }

        public static void ErrorListThrow(List<ErrorInnerResource> errorList)
        {
            string json = JsonConvert.SerializeObject(errorList);
            throw new ArgumentException(json);
        }
    }
}
