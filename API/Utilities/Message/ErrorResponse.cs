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
}
