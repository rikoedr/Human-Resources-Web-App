using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class RoleRepository : GeneralRepository<Role>, IRoleRepository
    {
        public RoleRepository(HumanResourcesDbContext context) : base(context)
        {

        }

        public Role? GetByName(string name)
        {
            return base.context.Set<Role>().FirstOrDefault(role => role.Name.ToLower() == name.ToLower());
        }
    }
}
