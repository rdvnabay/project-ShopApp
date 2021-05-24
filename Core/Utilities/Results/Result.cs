namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success)
        {
            Success = success;
        }

        public Result(bool success,string message):this(success)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
