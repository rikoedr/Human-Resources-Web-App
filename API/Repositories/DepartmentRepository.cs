using API.Contracts;
using API.Data;
using API.Models;
using System.Xml.Linq;

namespace API.Repositories;

public class DepartmentRepository : GeneralRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(HumanResourcesDbContext context) : base(context)
    {
    }

    public Department? GetByCode(string code)
    {
        return base.context.Set<Department>().FirstOrDefault(department => department.Code.ToLower() == code.ToLower());
    }

    public Department? GetByName(string name)
    {
        return base.context.Set<Department>().FirstOrDefault(department => department.Name.ToLower() == name.ToLower());
    }
}
