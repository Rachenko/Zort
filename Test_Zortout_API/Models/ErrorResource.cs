namespace Test_Zortout_API.Models
{
    public class ErrorResource
    {
        public bool Success => false;

        public Object Data { get; set; }
        public List<ErrorInnerResource> errors { get; private set; }

        public ErrorResource(List<ErrorInnerResource> errorLists)
        {
            Data = null;
            errors = errorLists;
        }
    }
}
