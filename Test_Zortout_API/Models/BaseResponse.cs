namespace Test_Zortout_API.Models
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; private set; }

        public T Data { get; private set; }
        public ErrorInnerResource Error { get; private set; }

        protected BaseResponse(T data)
        {
            Success = true;
            Data = data;
            Error = default;
        }

        protected BaseResponse(string errorMessage, int errorCode = 500)
        {
            Success = false;
            Data = default;
        }
    }
}
