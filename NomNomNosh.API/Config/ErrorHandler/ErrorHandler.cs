using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace NomNomNosh.API.Config.ErrorHandler
{
    public class ErrorHandler : IErrorHandler
    {
        public ActionResult HandleError(Exception ex)
        {
            switch (ex)
            {
                case ArgumentException:
                    return new BadRequestObjectResult(ex.Message);
                case UnauthorizedAccessException:
                    return new UnauthorizedObjectResult(ex.Message);
                case InvalidOperationException:
                    return new NotFoundObjectResult(ex.Message);
                default:
                    return new ObjectResult(ex.Message)
                    {
                        StatusCode = StatusCodes.Status500InternalServerError
                    };
            }
        }
    }
}