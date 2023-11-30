using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class JobHistoryRepository : GeneralRepository<JobHistory>, IJobHistoryRepository
{
    public JobHistoryRepository(HumanResourcesDbContext context) : base(context)
    {
    }
}
