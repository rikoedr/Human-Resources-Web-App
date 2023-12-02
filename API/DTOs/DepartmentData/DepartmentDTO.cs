using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.DTOs.DepartmentData;

public class DepartmentDTO
{
    Guid Guid { get; set; }
    public int Code { get; set; }
    public string Name { get; set; }
    public Guid? ManagerGuid { get; set; }

    public static explicit operator DepartmentDTO(Department data)
    {
        return new DepartmentDTO
        {
            Guid = data.Guid,
            Code = data.Code,
            ManagerGuid = data.ManagerGuid,
            Name = data.Name
        };
    }
}
