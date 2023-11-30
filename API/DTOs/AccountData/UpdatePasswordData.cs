namespace API.DTOs.AccountData;

public class UpdatePasswordData
{
    public string Email { get; set; }
    public int Otp { get; set; }
    public string Password { get; set; }
    public string ConfirmationPassword { get; set; }
}
