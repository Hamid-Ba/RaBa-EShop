using Framework.Application;
using Framework.Presentation.Api;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected ApiResult CommandResult(OperationResult result) => new ApiResult
        {
            MetaData = new()
            {
                Message = result.Message,
                Status = result.Status.MapApiStatus()
            },
            IsSuccess = result.Status == OperationResultStatus.Success
        };

        protected ApiResult<TData> QueryResult<TData>(TData data) => new ApiResult<TData>
        {
            Data = data,
            IsSuccess = true,
            MetaData = new()
            {
                Message = "عملیات با موفقیت انجام شد",
                Status = ApiStatusCode.Success
            }
        };
    }

    public static class EnumHelper
    {
        public static ApiStatusCode MapApiStatus(this OperationResultStatus status)
        {
            switch (status)
            {
                case OperationResultStatus.Success:
                    return ApiStatusCode.Success;

                case OperationResultStatus.NotFound:
                    return ApiStatusCode.NotFound;

                case OperationResultStatus.Error:
                    return ApiStatusCode.BadRequest;
            }

            return ApiStatusCode.LogicError;
        }
    }
}