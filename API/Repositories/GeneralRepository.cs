using API.Contracts;
using API.Data;

namespace API.Repositories
{
    public class GeneralRepository<TEntity> : IGeneralRepository<TEntity> where TEntity : class
    {
        protected readonly HumanResourcesDbContext context;

        public GeneralRepository(HumanResourcesDbContext context)
        {
            this.context = context;
        }

        public TEntity? Create(Guid guid)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity? GetByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
