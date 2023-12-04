using API.Models;
using API.Utilities;

namespace API.Contracts;

public interface IEmployeeRepository : IGeneralRepository<Employee>
{
    public bool IsPhoneNumberRegistered(string phoneNumber);
    public RepositoryResult<IEnumerable<Employee>> GetByJob(Guid jobGuid);
    public RepositoryResult<IEnumerable<Employee>> GetByDepartment(Guid departmentGuid);

}

