using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("job_history")]
public class JobHistory : BaseEntity
{
    [Required, Column("employee_guid")]
    public Guid EmployeeGuid { get; set; }

    [Required, Column("job_guid")]
    public Guid JobGuid { get; set; }

    [Required, Column("start_date")]
    public DateTime StartDate { get; set; }

    [Column("end_date")]
    public DateTime? EndDate { get; set; }

    // Table cardinality
    public Employee? Employee { get; set; }
    public Job? Job { get; set; }
}
