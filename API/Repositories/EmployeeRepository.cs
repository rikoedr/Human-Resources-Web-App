using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(HumanResourcesDbContext context) : base(context)
    {
    }

    public bool IsPhoneNumberRegistered(string phoneNumber)
    {
        return base.context.Set<Employee>().Any(employee => employee.PhoneNumber == phoneNumber);
    }
}
