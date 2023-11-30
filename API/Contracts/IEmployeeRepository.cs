using API.Models;

namespace API.Contracts;

public interface IEmployeeRepository : IGeneralRepository<Employee>
{
    public bool IsPhoneNumberRegistered(string phoneNumber);

}

