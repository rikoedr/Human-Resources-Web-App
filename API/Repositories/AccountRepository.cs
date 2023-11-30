using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class AccountRepository : GeneralRepository<Account>, IAccountRepository
{
    public AccountRepository(HumanResourcesDbContext context) : base(context)
    {
    }

    public Account? GetByEmail(string email)
    {
        return base.context.Set<Account>().FirstOrDefault(account => account.Email == email);
    }

    public bool IsEmailRegistered(string email)
    {
        return base.context.Set<Account>().Any(account => account.Email == email);
    }

}
