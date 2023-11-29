namespace API.DTOs.Auth;

public class ClaimData
{
    public string NameIdentifier { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<string> Role { get; set; }
}
