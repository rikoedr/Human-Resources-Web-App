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

        public TEntity? Create(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();

                return entity;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity? GetByGuid(Guid guid)
        {
            return context.Set<TEntity>().Find(guid);
        }

        public bool Update(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Update(entity);
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
