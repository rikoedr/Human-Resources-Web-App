using API.Contracts;
using API.Data;
using API.Utilities;
using API.Utilities.Message;

namespace API.Repositories
{
    public class GeneralRepository<TEntity> : IGeneralRepository<TEntity> where TEntity : class
    {
        protected readonly HumanResourcesDbContext context;

        public GeneralRepository(HumanResourcesDbContext context)
        {
            this.context = context;
        }

        public RepositoryResult<string> Update(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Update(entity);
                context.SaveChanges();

                return new RepositoryResult<string>()
                {
                    IsSuccess = true,
                    Exception = Message.NoException,
                    Data = Message.NoData
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult<string>()
                {
                    IsSuccess = false,
                    Exception = ex.InnerException.Message,
                    Data = Message.NoData
                };
            }
        }

        public TEntity? GetByGuid(Guid guid)
        {
            return context.Set<TEntity>().Find(guid);
        }

        public RepositoryResult<string> Create(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();

                return new RepositoryResult<string>()
                {
                    IsSuccess = true,
                    Exception = Message.NoException,
                    Data = Message.NoData
                };
            }
            catch(Exception ex)
            {
                return new RepositoryResult<string>()
                {
                    IsSuccess = false,
                    Exception = ex.InnerException.Message,
                    Data = Message.NoData
                };
            }
        }

        public RepositoryResult<string> Delete(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();

                return new RepositoryResult<string>()
                {
                    IsSuccess = true,
                    Exception = Message.NoException,
                    Data = Message.NoData
                };
            }
            catch(Exception ex)
            {
                return new RepositoryResult<string>()
                {
                    IsSuccess = false,
                    Exception = ex.InnerException.Message,
                    Data = Message.NoData
                };
            }
        }

        public RepositoryResult<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                var result = context.Set<TEntity>().ToList();

                return new RepositoryResult<IEnumerable<TEntity>>()
                {
                    IsSuccess = true,
                    Exception = Message.NoException,
                    Data = result
                };
            }
            catch(Exception ex)
            {
                return new RepositoryResult<IEnumerable<TEntity>>()
                {
                    IsSuccess = false,
                    Exception = ex.InnerException.Message,
                    Data = null
                };
            }
        }

        public RepositoryResult<TEntity> TakeById(Guid guid)
        {
            try
            {
                var result = context.Set<TEntity>().Find(guid);

                return new RepositoryResult<TEntity>()
                {
                    IsSuccess = true,
                    Exception = Message.NoException,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult<TEntity>()
                {
                    IsSuccess = false,
                    Exception = ex.InnerException.Message,
                    Data = null
                };
            }
        }
    }
}
