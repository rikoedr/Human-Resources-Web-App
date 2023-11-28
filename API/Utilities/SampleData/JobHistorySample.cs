using API.Models;

namespace API.Utilities.SampleData;

public class JobHistorySample
{
    public static JobHistory JohnDoe()
    {
        return new JobHistory
        {
            Guid = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            EmployeeGuid = EmployeeSample.JohnDoe().Guid,
            JobGuid = JobSample.FinancialAnalyst().Guid,
            StartDate = new DateTime(2021, 1, 1),
            EndDate = null
        };
    }
    public static JobHistory JaneSmith()
    {
        return new JobHistory
        {
            Guid = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            EmployeeGuid = EmployeeSample.JaneSmith().Guid,
            JobGuid = JobSample.SoftwareDeveloper().Guid,
            StartDate = new DateTime(2020, 1, 1),
            EndDate = new DateTime(2023, 1, 1)
        };
    }

    public static JobHistory BobJohnson()
    {
        return new JobHistory
        {
            Guid = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            EmployeeGuid = EmployeeSample.BobJohnson().Guid,
            JobGuid = JobSample.RecruitmentSpecialist().Guid,
            StartDate = new DateTime(2018, 1, 1),
            EndDate = null
        };
    }

}
