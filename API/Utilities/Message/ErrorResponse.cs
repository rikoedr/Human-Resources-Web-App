using API.Utilities.Handlers;
using System.Net;

namespace API.Utilities.Message;

public class ErrorResponse
{
    public static ResponseErrorHandler EmailPasswordInvalid()
    {
        var response = new ResponseErrorHandler
        {
            Code = StatusCodes.Status401Unauthorized,
            Status = HttpStatusCode.Unauthorized.ToString(),
            Message = "Email or Password is Invalid!"
        };

        return response;
    }

    public static ResponseErrorHandler DataNotFound(string message)
    {
        var response = new ResponseErrorHandler
        {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Message = message
        };

        return response;
    }

    public static ResponseErrorHandler InternalServerError(string error)
    {
        var response = new ResponseErrorHandler
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Message = "Request failed, there was an error on the server side",
            Error = error
        };

        return response;
    }

    public static ResponseErrorHandler Conflict(string message)
    {
        var response = new ResponseErrorHandler
        {
            Code = StatusCodes.Status409Conflict,
            Status = HttpStatusCode.Conflict.ToString(),
            Message = message
        };

        return response;
    }

    public static ResponseErrorHandler Conflict(string message, string error)
    {
        var response = new ResponseErrorHandler
        {
            Code = StatusCodes.Status409Conflict,
            Status = HttpStatusCode.Conflict.ToString(),
            Message = message,
            Error = error
        };

        return response;
    }

    public static ResponseErrorHandler Unauthorized(string message)
    {
        var response = new ResponseErrorHandler
        {
            Code = StatusCodes.Status401Unauthorized,
            Status = HttpStatusCode.Unauthorized.ToString(),
            Message = message
        };

        return response;
    }

}
