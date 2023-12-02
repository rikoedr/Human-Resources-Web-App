using API.Contracts;
using API.Data;
using API.Models;
using API.Utilities;
using API.Utilities.Message;

namespace API.Repositories;

public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(HumanResourcesDbContext context) : base(context)
    {
    }

    public RepositoryResult<IEnumerable<Employee>> GetByJob(Guid jobGuid)
    {
        try
        {
            var result = base.context.Set<Employee>().Where(item => item.JobGuid == jobGuid);

            return new RepositoryResult<IEnumerable<Employee>>
            {
                IsSuccess = true,
                Exception = Message.NoException,
                Data = result
            };
        }
        catch(Exception ex)
        {
            return new RepositoryResult<IEnumerable<Employee>>
            {
                IsSuccess = false,
                Exception = ex.InnerException.Message,
                Data = Enumerable.Empty<Employee>()
            };
        }
    }

    public bool IsPhoneNumberRegistered(string phoneNumber)
    {
        return base.context.Set<Employee>().Any(employee => employee.PhoneNumber == phoneNumber);
    }
}
