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

    public Job? GetByCode(int code)
    {
        return base.context.Set<Job>().FirstOrDefault(job => job.Code == code);

    }

    public Job? GetByName(string name)
    {
        return base.context.Set<Job>().FirstOrDefault(job => job.Name.ToLower() == name.ToLower());
    }

    public bool IsCodeRegistered(int code)
    {
        return base.context.Set<Job>().Any(job => job.Code == code);
    }

    public bool IsNameRegistered(string name)
    {
        return base.context.Set<Job>().Any(job => job.Name.ToLower() == name.ToLower());

    }
}
