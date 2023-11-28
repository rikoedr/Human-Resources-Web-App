using API.Models;

namespace API.Utilities.SampleData;

public class JobSample
{
    public static Job FinancialAnalyst()
    {
        return new Job
        {
            Guid = Guid.Parse("1105117d-ed96-4206-bd43-0e13b7342770"),
            Code = "101",
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            Name = "Financial Analyst",
            MinSalary = 5_000_000,
            MaxSalary = 7_500_000
        };
    }

    public static Job SoftwareDeveloper()
    {
        return new Job
        {
            Guid = Guid.Parse("25abd2bc-c0fe-411a-ba24-f26cbae523c2"),
            Code = "601",
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            Name = "Software Developer",
            MinSalary = 6_000_000,
            MaxSalary = 8_000_000
        };
    }

    public static Job RecruitmentSpecialist()
    {
        return new Job
        {
            Guid = Guid.Parse("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"),
            Code = "701",
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            Name = "Recruitment Specialist",
            MinSalary = 5_000_000,
            MaxSalary = 7_000_000
        };
    }
}
