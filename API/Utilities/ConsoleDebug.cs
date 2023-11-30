using System.Diagnostics;

namespace API.Utilities;

public class ConsoleDebug
{
    public static void Print(string message, object obj)
    {
        Debug.WriteLine($"{message} : {obj}");
    }
}
