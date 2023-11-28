using API.Models;

namespace API.Utilities.SampleData;

public class RoleSample
{
    public static Role Admin()
    {
        return new Role
        {
            Guid = Guid.Parse("aca8df20-f7d1-464c-947a-b22bc96c2394"),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            Name = "Admin"
        };
    }

    public static Role Manager()
    {
        return new Role
        {
            Guid = Guid.Parse("8d1da011-8574-4be4-9f64-657254f764d6"),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            Name = "Manager"
        };
    }

    public static Role Staff()
    {
        return new Role
        {
            Guid = Guid.Parse("aad98c8c-c71e-46f4-99c1-2d073ecb467f"),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            Name = "Staff"
        };
    }
}
