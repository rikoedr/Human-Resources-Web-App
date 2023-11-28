using API.Models;

namespace API.Utilities.SampleData;

public class AccountRoleSample
{
    public static AccountRole JohnDoe()
    {
        return new AccountRole
        {
            Guid = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            AccountGuid = EmployeeSample.JohnDoe().Guid,
            RoleGuid = RoleSample.Staff().Guid
        };
    }

    public static AccountRole JaneSmith()
    {
        return new AccountRole
        {
            Guid = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            AccountGuid = EmployeeSample.JaneSmith().Guid,
            RoleGuid = RoleSample.Manager().Guid
        };
    }

    public static AccountRole BobJohnson()
    {
        return new AccountRole
        {
            Guid = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            AccountGuid = EmployeeSample.BobJohnson().Guid,
            RoleGuid = RoleSample.Admin().Guid
        };
    }
}
