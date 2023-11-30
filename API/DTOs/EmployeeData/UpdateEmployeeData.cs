using API.Models;
using API.Utilities;

namespace API.DTOs.EmployeeData;

public class UpdateEmployeeData
{
    public Guid Guid { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HiringDate { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string DepartmentCode { get; set; }
    public string JobCode { get; set; }
    public string Role { get; set; }
}
