using API.Models;
using API.Utilities.Handlers;

namespace API.Utilities.SampleData;

public class AccountSample
{
    public static Account JohnDoe()
    {
        return new Account
        {
            Guid = EmployeeSample.JohnDoe().Guid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            IsDisabled = false,
            IsOtpUsed = true,
            OTP = 123456,
            OtpExpiredTime = DateTime.Now,
            Password = HashHandler.Password("abcd123456")
        };
    }

    public static Account JaneSmith()
    {
        return new Account
        {
            Guid = EmployeeSample.JaneSmith().Guid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            IsDisabled = false,
            IsOtpUsed = true,
            OTP = 123456,
            OtpExpiredTime = DateTime.Now,
            Password = HashHandler.Password("abcd123456")
        };
    }

    public static Account BobJohnson()
    {
        return new Account
        {
            Guid = EmployeeSample.BobJohnson().Guid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            IsDisabled = false,
            IsOtpUsed = true,
            OTP = 123456,
            OtpExpiredTime = DateTime.Now,
            Password = HashHandler.Password("abcd123456")
        };
    }


}
