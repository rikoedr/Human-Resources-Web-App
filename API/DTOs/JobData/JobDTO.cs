using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.DTOs.JobData;

public class JobDTO
{
    public Guid Guid { get; set; }
    public int Code { get; set; }
    public String Name { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }

    public static explicit operator JobDTO(Job dto)
    {
        return new JobDTO
        {
            Guid = dto.Guid,
            Code = dto.Code,
            Name = dto.Name,
            MinSalary = dto.MinSalary,
            MaxSalary = dto.MaxSalary
        };
    }

    public static implicit operator Job(JobDTO dto)
    {
        return new Job
        {
            Guid = dto.Guid,
            Code = dto.Code,
            Name = dto.Name,
            MinSalary = dto.MinSalary,
            MaxSalary = dto.MaxSalary,
            ModifiedDate = DateTime.Now
        };
    }
}
