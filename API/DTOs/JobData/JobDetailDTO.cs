using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.DTOs.JobData;

public class JobDetailDTO
{
    public Guid Guid { get; set; }
    public int Code { get; set; }
    public string Name { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }
    public IEnumerable<JobEmployeeDTO> Employees { get; set; }

    public static explicit operator JobDetailDTO(Job data)
    {
        return new JobDetailDTO
        {
            Guid = data.Guid,
            Code = data.Code,
            Name = data.Name,
            MinSalary = data.MinSalary,
            MaxSalary = data.MaxSalary,
            Employees = Enumerable.Empty<JobEmployeeDTO>()
        };
    }
}
