using API.Models;

namespace API.DTOs.DepartmentData;

public class CreateDepartmentDTO
{
    public int Code { get; set; }
    public string Name { get; set; }
    public Guid? ManagerGuid { get; set; }

    public static implicit operator Department(CreateDepartmentDTO dto)
    {
        return new Department
        {
            Guid = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            Code = dto.Code,
            Name = dto.Name,
            ManagerGuid = dto.ManagerGuid
        };
    }
}
