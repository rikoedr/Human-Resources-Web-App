using API.Contracts;
using API.Data;
using API.Models;
using System.Xml.Linq;

namespace API.Repositories;

public class JobRepository : GeneralRepository<Job>, IJobRepository
{
    public JobRepository(HumanResourcesDbContext context) : base(context)
    {
    }

    public Job? GetByCode(string code)
    {
        return base.context.Set<Job>().FirstOrDefault(job => job.Code.ToLower() == code.ToLower());

    }

    public Job? GetByName(string name)
    {
        return base.context.Set<Job>().FirstOrDefault(job => job.Name.ToLower() == name.ToLower());
    }
}
