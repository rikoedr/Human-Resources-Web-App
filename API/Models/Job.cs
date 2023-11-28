using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_jobs")]
public class Job : BaseEntity
{
    [Required, Column("code", TypeName = "nvarchar(3)")]
    public string Code { get; set; }

    [Required, Column("name", TypeName = "nvarchar(50)")]
    public String Name { get; set; }

    [Required, Column("min_salary")]
    public int MinSalary { get; set; }

    [Required, Column("max_salary")]
    public int MaxSalary { get; set; }
    
    // Table cardinality
    public IEnumerable<Employee>? Employees { get; set; }
    public IEnumerable<JobHistory>? JobHistories { get; set; }
}
