using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.DTOs.DepartmentData;

public class DepartmentDetailDTO
{
    public Guid Guid { get; set; }
    public int Code { get; set; }
    public string Name { get; set; }
    public Guid? ManagerGuid { get; set; }
    public IEnumerable<DepartmentEmployeeDTO>? Employees { get; set; }

    public static explicit operator DepartmentDetailDTO(Department data)
    {
        return new DepartmentDetailDTO
        {
            Guid = data.Guid,
            Code = data.Code,
            ManagerGuid = data.ManagerGuid,
            Name = data.Name,
            Employees = Enumerable.Empty<DepartmentEmployeeDTO>()
        };
    }
}
