using API.Models;

namespace API.DTOs.JobData;

public class CreateJobDTO
{
    public int Code { get; set; }
    public String Name { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }

    public static implicit operator Job(CreateJobDTO dto)
    {
        return new Job
        {
            Guid = Guid.NewGuid(),
            Code = dto.Code,
            Name = dto.Name,
            MinSalary = dto.MinSalary,
            MaxSalary = dto.MaxSalary,
            ModifiedDate = DateTime.Now,
            CreatedDate = DateTime.Now
        };
    }
}
