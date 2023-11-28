namespace API.Utilities.Handlers;

public class HashHandler
{
    private static string RandomSalt()
    {
        return BCrypt.Net.BCrypt.GenerateSalt(12);
    }

    public static string Password(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, RandomSalt());
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
