using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace NomNomNosh.API.Config
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
                default:
                    return new ObjectResult(ex.Message)
                    {
                        StatusCode = StatusCodes.Status500InternalServerError
                    };
            }
        }
    }
}