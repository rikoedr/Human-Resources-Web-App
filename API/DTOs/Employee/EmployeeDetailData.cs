using API.Utilities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Employee;

public class EmployeeDetailData
{
    public Guid Guid { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HiringDate { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Department { get; set; }
    public string Job { get; set; }
    public bool IsAccountDisabled { get; set; }
}
