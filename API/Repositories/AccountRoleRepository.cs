using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class AccountRoleRepository : GeneralRepository<AccountRole>, IAccountRoleRepository
{
    public AccountRoleRepository(HumanResourcesDbContext context) : base(context)
    {
    }

    public IEnumerable<AccountRole> GetByAccountGuid(Guid accountGuid)
    {
        return base.context.Set<AccountRole>().Where(accountRole => accountRole.AccountGuid == accountGuid);
    }
}
