using API.Models;

namespace API.Contracts;

public interface IDepartmentRepository : IGeneralRepository<Department>
{
    public Department? GetByName(string name);
    public Department? GetByCode(int code);
}
