using API.Utilities.Handlers;

namespace API.Utilities.Message;

public class OkResponse
{
    public static ResponseOkHandler<object> SuccessRetrieveData()
    {
        var response = new ResponseOkHandler<object>("Success to retrieve data");

        return response;
    }

    public static ResponseOkHandler<object> DataDeletedSuccessfully()
    {
        var response = new ResponseOkHandler<object>("Data deleted successfully.");

        return response;
    }
}
