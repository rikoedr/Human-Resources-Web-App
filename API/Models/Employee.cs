using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace API.Models;

[Table("tb_employees")]
public class Employee
{
    [Required, Column("employee_id", TypeName = "nvarchar(12)")]
    public string EmployeeID { get; set; }

    [Required, Column("first_name", TypeName = "nvarchar(50)")]
    public string FirstName { get; set; }

    [Column("last_name", TypeName = "nvarchar(50)")]
    public string? LastName { get; set; }

    [Required, Column("birth_date")]
    public DateTime BirthDate { get; set; }

    [Required, Column("hiring_date")]
    public DateTime HiringDate { get; set; }

    [Required, Column("gender")]
    public Gender Gender { get; set; }

    [Required, Column("email", TypeName = "nvarchar(50)")]
    public string Email { get; set; }

    [Required, Column("phone_number", TypeName = "nvarchar(50)")]
    public string PhoneNumber { get; set; }

    [Required, Column("department_guid")]
    public Guid DepartmentGuid { get; set; }

    [Required, Column("job_guid")]
    public Guid JobGuid { get; set; }

    //Table cardinality
    public Account? Account { get; set; }
    public Department? Department { get; set; }
    public Department? DepartmentManaged { get; set; }
    public Job? Job { get; set; }
    public IEnumerable<JobHistory>? JobHistories { get; set; }
}
