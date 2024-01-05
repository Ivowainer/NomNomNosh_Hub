using Microsoft.AspNetCore.Mvc;

namespace NomNomNosh.API.Config
{
    public interface IErrorHandler
    {
        ActionResult HandleError(Exception ex);
    }
}