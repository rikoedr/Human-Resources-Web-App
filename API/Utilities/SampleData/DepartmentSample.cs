using API.Models;

namespace API.Utilities.SampleData;

public class DepartmentSample
{
    public static Department Finance()
    {
        return new Department
        {
            Guid = Guid.Parse("7644ad73-57b6-4640-9e8d-f929ba01e694"),
            Code = "01",
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            Name = "Finance",
        };
    }

    public static Department InformationTechnology()
    {
        return new Department
        {
            Guid = Guid.Parse("9e0e4c05-cde2-4900-88f9-2a2b8ee0dad6"),
            Code = "06",
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            Name = "Information Technology",
        };
    }

    public static Department HumanResources()
    {
        return new Department
        {
            Guid = Guid.Parse("e8246140-6e0a-488e-b451-9321b6694736"),
            Code = "07",
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            Name = "Human Resources",
        };
    }
}
