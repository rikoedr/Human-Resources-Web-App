namespace API.Utilities.Handlers;

public class GenerateHandler
{
    public static int OTP()
    {
        return new Random().Next(100000, 1000000);
    }
}
