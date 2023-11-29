using API.Models;

namespace API.Utilities.SampleData;

public class EmployeeSample
{
    
    public static Employee JohnDoe()
    {
        return new Employee
        {
            Guid = Guid.Parse("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateTime(1990, 5, 15),
            HiringDate = new DateTime(2020, 10, 1),
            Gender = Gender.Male,
            PhoneNumber = "+123456789",
            DepartmentGuid = DepartmentSample.Finance().Guid,
            JobGuid = JobSample.FinancialAnalyst().Guid
        };
    }

    public static Employee JaneSmith()
    {
        return new Employee
        {
            Guid = Guid.Parse("0c05eaec-3052-40b2-badd-8e69153a8c50"),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            FirstName = "Jane",
            LastName = "Smith",
            BirthDate = new DateTime(1985, 8, 25),
            HiringDate = new DateTime(2019, 7, 15),
            Gender = Gender.Female,
            PhoneNumber = "+987654321",
            DepartmentGuid = DepartmentSample.InformationTechnology().Guid,
            JobGuid = JobSample.SoftwareDeveloper().Guid
        };
    }

    public static Employee BobJohnson()
    {
        return new Employee
        {
            Guid = Guid.Parse("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            FirstName = "Bob",
            LastName = "Johnson",
            BirthDate = new DateTime(1982, 3, 10),
            HiringDate = new DateTime(2018, 4, 20),
            Gender = Gender.Male,
            PhoneNumber = "+1122334455",
            DepartmentGuid = DepartmentSample.HumanResources().Guid,
            JobGuid = JobSample.RecruitmentSpecialist().Guid
        };
    }
}
