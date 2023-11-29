using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class JobRepository : GeneralRepository<Job>, IJobRepository
{
    public JobRepository(HumanResourcesDbContext context) : base(context)
    {
    }
}
