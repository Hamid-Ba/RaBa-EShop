namespace Framework.Presentation.Api
{
    public class ApiResult
	{
        public bool IsSuccess { get; set; }
        public ApiMetaDate MetaData { get; set; }
    }

    public class ApiResult<TData> : ApiResult
    {
        public TData Data { get; set; }
    }

    public class ApiMetaDate
    {
        public string Message { get; set; }
        public ApiStatusCode Status { get; set; }
    }

    public enum ApiStatusCode
    {
        Success = 1,
        NotFound = 2,
        BadRequest = 3,
        LogicError = 4,
        UnAuthorize = 5,
        ServerError
    }
}