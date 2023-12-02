using System.Diagnostics;

namespace API.Utilities;

public class QuickDebug
{
    public static void Print(string message, object obj)
    {
        Debug.WriteLine($"{message} : {obj}");
    }
}
