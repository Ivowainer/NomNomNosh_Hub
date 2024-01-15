using Microsoft.AspNetCore.Mvc;

namespace NomNomNosh.API.Config.ErrorHandler
{
    public interface IErrorHandler
    {
        ActionResult HandleError(Exception ex);
    }
}